using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotator : MonoBehaviour
{
    float _r, _phi,_theta;
    // Start is called before the first frame update

    public void Initialize(Vector3 pos)
    {
        _r = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));
        _theta = Mathf.Acos(pos.z / pos.x);
        _phi = Mathf.Atan(pos.y / pos.z);
    }

    Vector3 GetCartesian(float r, float phi, float theta)
    {
        return new Vector3(r * Mathf.Sin(theta) * Mathf.Cos(phi), r * Mathf.Sin(theta) * Mathf.Sin(phi), r * Mathf.Cos(theta));
    }

    Vector2 Rotate(Vector2 phiAndTheta)
    {
        return new Vector2(_phi + phiAndTheta.x,phiAndTheta.y+_theta);
    }
    private bool IsNewPositionInBoard(Vector3 newPosition)
    {
        return newPosition.x >= 0 && newPosition.x < 8 && newPosition.y >= 0 && newPosition.y < 8 && newPosition.z >= 0 && newPosition.z < 8;
    }
    private bool IsNewPositionSocketEmpty(Vector3 newPosition)
    {
        return FindObjectOfType<BoardCreator>().SocketLayers[(int)newPosition.y][(int)newPosition.x, (int)newPosition.z].TetrisPart == null;
    }
    public bool GetRotetedSpherical(ref Vector2 phiAndTheta)
    {
        Vector2 newSpherical=Rotate(phiAndTheta);
        Vector3 cartesian = GetCartesian(_r, newSpherical.x, newSpherical.y);
        Socket socket = GetComponent<PartMover>().CurrentSocket;
        cartesian.x += socket.XInArray;
        cartesian.y += socket.Layer;
        cartesian.z += socket.YInArray;
        if(IsNewPositionInBoard(cartesian)&& IsNewPositionSocketEmpty(cartesian))
        {
            phiAndTheta = newSpherical;
            return true;
        }
        return false;
    }

}
