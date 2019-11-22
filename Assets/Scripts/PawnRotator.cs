using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnRotator : MonoBehaviour
{
    List<PartRotator> _parts;
    List<Socket[,]> layers;
    // Start is called before the first frame update
    void Start()
    {
        _parts = new List<PartRotator>();
        GetComponent<TetrionInitializer>().Parts.ForEach(part => {
            _parts.Add(part.GetComponent<PartRotator>());
        });
        layers = FindObjectOfType<BoardCreator>().SocketLayers;
    }

    

    public void RotateLeft()
    {
        foreach(var part in _parts)
        {
            if(!part.isCanRotate(new Vector2(0, Mathf.PI / 2)))
            {
                return;
            }
        }
        Socket rootSocketPosition = _parts[0].GetComponent<PartMover>().CurrentSocket;
        foreach(var part in _parts)
        {
            Vector2 newPhiAndTheta = part.Rotate(new Vector2(0, Mathf.PI / 2));
            part.Phi = newPhiAndTheta.x;
            part.Theta = newPhiAndTheta.y;
            Vector3 newSocketPos = part.CountCartesian(part.R, newPhiAndTheta.x, newPhiAndTheta.y);
            Socket currSock = part.GetComponent<PartMover>().CurrentSocket;
            newSocketPos.x += rootSocketPosition.XInArray;
            newSocketPos.y += rootSocketPosition.Layer;
            newSocketPos.z += rootSocketPosition.YInArray;
            currSock.TetrisPart = null;
            Socket newSocket = layers[(int)Mathf.Ceil(newSocketPos.y)][(int)Mathf.Ceil(newSocketPos.x), (int)Mathf.Ceil(newSocketPos.z)];
            newSocket.TetrisPart =part.gameObject;
            part.transform.position=part.GetComponent<PartMover>().CurrentSocket.SocketPos;
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
