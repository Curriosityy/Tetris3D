using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class LayerFaller : MonoBehaviour
{
    List<Socket[,]> _layers;

    private void Start()
    {
        _layers = GetComponent<BoardCreator>().SocketLayers;
    }
    public void Fall(List<int> indexs)
    {
        foreach(var index in indexs)
        {
            FallOnLayer(index);
        }
    }
    private void FallOnLayer(int layerIndex)
    {
        for(int i=layerIndex+1;i<GameManager.y;i++)
        {
            foreach(var socket in _layers[i])
            {
                if(socket.TetrisPart!=null)
                {
                    int a = 0;
                    socket.TetrisPart.transform.Translate(Vector3.down);
                    socket.TetrisPart.GetComponent<PartMover>().Fall();

                }
            }
        }
    }

}

