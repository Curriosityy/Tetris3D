using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PawnRotator : MonoBehaviour
{
    List<PartRotator> _parts;
    Part _rootPart;
    List<Socket[,]> _layers;
    // Start is called before the first frame update
    void Start()
    {

        _parts = new List<PartRotator>();
        GetComponent<TetrionInitializer>().Parts.ForEach(part =>
        {
            _parts.Add(part.GetComponent<PartRotator>());
        });
        _layers = FindObjectOfType<BoardCreator>().SocketLayers;
        _parts.ForEach(part => 
        {
            if (part.transform.localPosition == Vector3.zero)
                _rootPart = part.GetComponent<Part>();
        });

    }


    public void RotateLeft()
    {
        RotateVertically(new Vector2(1, -1));
    }
    public void RotateUp()
    {
        RotateHorizontally(new Vector2(1, -1));
    }
    public void RotateRight()
    {
        RotateVertically(new Vector2(-1, 1));
    }
    public void RotateDown()
    {
        RotateHorizontally(new Vector2(-1, 1));
    }

    private void RotateVertically(Vector2 rotationValue)
    {
        List<Vector3> newLocalPositions = new List<Vector3>();
        Vector3 temp;
        Vector3Int newArrayPos;
        foreach (var part in _parts)
        {
            temp = part.RotateVertically(rotationValue);
            if (!part.IsRotationPosible(temp, _rootPart.CurrentSocket))
            {
                Debug.Log("cannot rotate");
                return;
            }
            newLocalPositions.Add(temp);
        }
        int i = 0;
        foreach (var part in _parts)
        {
            part.GetComponent<Part>().CurrentSocket.TetrisPart = null;
            newArrayPos = part.GetNewPositionInArray(newLocalPositions[i], _rootPart.CurrentSocket);
            _layers[newArrayPos.y][newArrayPos.x, newArrayPos.z].TetrisPart = part.gameObject;
            part.transform.localPosition = newLocalPositions[i];
            i++;
        }
    }
    private void RotateHorizontally(Vector2 rotationValue)
    {
        List<Vector3> newLocalPositions = new List<Vector3>();
        Vector3 temp;
        Vector3Int newArrayPos;
        foreach (var part in _parts)
        {
            temp = part.RotateHorizontally(rotationValue);
            if (!part.IsRotationPosible(temp, _rootPart.CurrentSocket))
            {
                Debug.Log("cannot rotate");
                return;
            }
            newLocalPositions.Add(temp);
        }
        int i = 0;
        foreach (var part in _parts)
        {
            part.GetComponent<Part>().CurrentSocket.TetrisPart = null;
            newArrayPos = part.GetNewPositionInArray(newLocalPositions[i], _rootPart.CurrentSocket);
            _layers[newArrayPos.y][newArrayPos.x, newArrayPos.z].TetrisPart = part.gameObject;
            part.transform.localPosition = newLocalPositions[i];
            i++;
        }
    }

}
