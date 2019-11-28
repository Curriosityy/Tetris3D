using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotator : MonoBehaviour
{
    //rotation value is -1 or 1
    public Vector3 RotateVertically(Vector2 rotationValue)
    {
        Vector3 rotatedPosition = transform.localPosition;
        float temp = rotatedPosition.x;
        rotatedPosition.x = rotatedPosition.z;
        rotatedPosition.z = temp;
        rotatedPosition.x *= rotationValue.x;
        rotatedPosition.z *= rotationValue.y;
        return rotatedPosition;
    }
    //rotation value is -1 or 1
    public Vector3 RotateHorizontally(Vector2 rotationValue)
    {
        Vector3 rotatedPosition = transform.localPosition;
        float temp = rotatedPosition.y;
        rotatedPosition.y = rotatedPosition.z;
        rotatedPosition.z = temp;
        rotatedPosition.y *= rotationValue.x;
        rotatedPosition.z *= rotationValue.y;
        return rotatedPosition;
    }


    private bool IsNewPositionInBoard(Vector3 newPosition)
    {
        return newPosition.x >= 0 && newPosition.x < GameManager.x && newPosition.y >= 0 && newPosition.y < GameManager.y+4 && newPosition.z >= 0 && newPosition.z < GameManager.z;
    }
    private bool IsNewPositionSocketEmpty(Vector3 newPosition)
    {
        Socket socket = FindObjectOfType<BoardCreator>().SocketLayers[(int)newPosition.y][(int)newPosition.x, (int)newPosition.z];
        if(socket.TetrisPart==null || socket.TetrisPart==gameObject || socket.TetrisPart.transform.parent==transform.parent)
        {
            return true;
        }
       // if(socket.TetrisPart==gameObject || socket.TetrisPart.transform.parent==gameObject.transform.parent)
        return false;
    }
    public bool IsRotationPosible(Vector3 newPosition,Socket rootSocket)
    {
        Vector3Int newArrayPos = GetNewPositionInArray(newPosition, rootSocket);
        if(IsNewPositionInBoard(newArrayPos) &&IsNewPositionSocketEmpty(newArrayPos))
        {
            return true;
        }
        return false;
    }
    public Vector3Int GetNewPositionInArray(Vector3 newLocalPosition, Socket rootSocket)
    {
        return new Vector3Int((int)newLocalPosition.x + rootSocket.XInArray, (int)newLocalPosition.y + rootSocket.Layer, (int)newLocalPosition.z + rootSocket.YInArray);
    }
}
