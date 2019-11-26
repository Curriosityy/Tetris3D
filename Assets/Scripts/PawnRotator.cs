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

        foreach(var part in _parts)
        {
            if (part.transform.localPosition==new Vector3(0,0,0))
            {
                _rootPart = part.GetComponent<Part>();
                break;
            }
        }

    }


    public void Rotate(float phi, float theta)
    {
        List<SphericalCooridnate> newCoords = new List<SphericalCooridnate>();
        SphericalCooridnate newCoodr;
        foreach (var part in _parts)
        {
            newCoodr = part.SphericalCooridnate.RotateCoordinateBy(phi, theta);
            if (!part.IsRotationPosible(newCoodr, _rootPart.CurrentSocket))
            {
                return;
            }
            newCoords.Add(newCoodr);

        }
        int i = 0;
        foreach (var part in _parts)
        {
            Debug.Log("current coord=" + part.SphericalCooridnate + " " + part.SphericalCooridnate.GetCartesianPoint() + " newCoord=" + newCoords[i] + " " + newCoords[i].GetCartesianPoint());
            part.SphericalCooridnate = newCoords[i];
            Vector3Int newSocketPos = Vector3Int.RoundToInt(part.SphericalCooridnate.GetCartesianPoint());
            Socket _rootSocket = _rootPart.CurrentSocket;
            newSocketPos.x += _rootSocket.XInArray;
            newSocketPos.y += _rootSocket.Layer;
            newSocketPos.z += _rootSocket.YInArray;
            part.GetComponent<Part>().CurrentSocket.TetrisPart = null;
            Socket newSocket = _layers[newSocketPos.y][newSocketPos.x, newSocketPos.z];
            
            newSocket.TetrisPart = part.gameObject;
            part.transform.position = newSocket.SocketPos;
            i++;
        }
    }

    public void RotateLeft()
    {
        Rotate(0, Mathf.PI / 2);
    }
    public void RotateUp()
    {
        Rotate(Mathf.PI / 2, 0);
    }
    public void RotateRight()
    {
        Rotate(0, -Mathf.PI / 2);
    }
    public void RotateDown()
    {
        Rotate(-Mathf.PI / 2, 0);
    }
}
