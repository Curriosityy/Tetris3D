using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardMatcher : MonoBehaviour
{
    List<Socket[,]> socketLayers;
    void Start()
    {
        socketLayers = GetComponent<BoardCreator>().SocketLayers;
    }
    private bool CheckIfLayerIsFull(Socket[,] layer)
    {
        foreach(var socket in layer)
        {
            if(!socket.CheckTetrisSocket())
            {
                return false;
            }
        }
        return true;
    }
    private void DestroyLayers()
    {
        foreach (var layer in socketLayers)
        {
            if(CheckIfLayerIsFull(layer))
            {
                DeactivateLayer(layer);
            }
        }
    }
    private void DeactivateLayer(Socket[,] layer)
    {
        foreach(var socket in layer)
        {
            socket.TetrisPart.SetActive(false);
            socket.TetrisPart = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
