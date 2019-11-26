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
            newCoodr = part.SphericalCooridnate.RotateCoordinateBy(0, Mathf.PI / 2);
            if (!part.IsRotationPosible(newCoodr))
            {
                return;
            }
            newCoords.Add(newCoodr);

        }
        foreach(var part in _parts)
        {
            //Vector2 newPhiAndTheta = part.Rotate(new Vector2(0, Mathf.PI / 2));
            //part.Phi = newPhiAndTheta.x;
            //part.Theta = newPhiAndTheta.y;
            //Vector3 newSocketPos = part.CountCartesian(part.R, newPhiAndTheta.x, newPhiAndTheta.y);
            //Socket currSock = part.GetComponent<PartMover>().CurrentSocket;
            //newSocketPos.x += rootSocketPosition.XInArray;
            //newSocketPos.y += rootSocketPosition.Layer;
            //newSocketPos.z += rootSocketPosition.YInArray;
            //currSock.TetrisPart = null;
            //Socket newSocket = layers[(int)Mathf.Ceil(newSocketPos.y)][(int)Mathf.Ceil(newSocketPos.x), (int)Mathf.Ceil(newSocketPos.z)];
            //newSocket.TetrisPart =part.gameObject;
            //part.transform.position=part.GetComponent<PartMover>().CurrentSocket.SocketPos;
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
