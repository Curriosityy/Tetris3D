using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnRotator : MonoBehaviour
{
    List<PartRotator> _parts;
    Part _rootPart;
    List<Socket[,]> _layers;
    // Start is called before the first frame update
    void Start()
    {
        
        _parts = new List<PartRotator>();
        GetComponent<TetrionInitializer>().Parts.ForEach(part => {
            _parts.Add(part.GetComponent<PartRotator>());
        });
        _layers = FindObjectOfType<BoardCreator>().SocketLayers;
        _rootPart = _parts[1].GetComponent<Part>();
    }

    

    public void RotateLeft()
    {
        List<SphericalCooridnate> newCoords = new List<SphericalCooridnate>();
        SphericalCooridnate newCoodr;
        foreach(var part in _parts)
        {
            newCoodr = part.SphericalCooridnate.RotateCoordinateBy(0, Mathf.PI/2);
            if (!part.IsRotationPosible(newCoodr,_rootPart.CurrentSocket))
            {
                return;
            }
            newCoords.Add(newCoodr);

        }
        int i = 0;
        foreach(var part in _parts)
        {
            Debug.Log("current coord="+part.SphericalCooridnate+" "+part.SphericalCooridnate.GetCartesianPoint()+" newCoord="+newCoords[i]+" "+newCoords[i].GetCartesianPoint());
            part.SphericalCooridnate = newCoords[i];
            Vector3 newSocketPos = part.SphericalCooridnate.GetCartesianPoint();
            Socket _rootSocket = _rootPart.CurrentSocket;
            newSocketPos.x += _rootSocket.XInArray;
            newSocketPos.y += _rootSocket.Layer;
            newSocketPos.z += _rootSocket.YInArray;
            part.GetComponent<Part>().CurrentSocket.TetrisPart = null;
            Socket newSocket = _layers[(int)Mathf.Ceil(newSocketPos.y)][(int)Mathf.Ceil(newSocketPos.x), (int)Mathf.Ceil(newSocketPos.z)];
            newSocket.TetrisPart =part.gameObject;
            part.transform.position = newSocket.SocketPos;
            i++;
        }
        
    }
    void RotateUp()
    {

    }
    void RotateRight()
    {

    }
    void RotateDown()
    {

    }
}
