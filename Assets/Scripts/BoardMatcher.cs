using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class BoardMatcher : MonoBehaviour
{
    List<Socket[,]> _socketLayers;
    BattleManager _battleManager;
    void Start()
    {
        _socketLayers = GetComponent<BoardCreator>().SocketLayers;
        _battleManager = FindObjectOfType<BattleManager>();
    }
    private bool CheckIfLayerIsFull(Socket[,] layer)
    {
        foreach(var socket in layer)
        {
            if(socket.IsSocketEmpty())
            {
                return false;
            }
        }
        return true;
    }
    public List<int> DestroyLayers()
    {
        List<int> destroyedLayers = new List<int>();
        int index = 0;
        foreach (var layer in _socketLayers)
        {
            if (CheckIfLayerIsFull(layer))
            {
                DeactivateLayer(layer);
                destroyedLayers.Add(index);
            }
            index++;
        }
        return destroyedLayers;
    }

    private void DeactivateLayer(Socket[,] layer)
    {
        foreach(var socket in layer)
        {
            socket.TetrisPart.SetActive(false);
            socket.TetrisPart = null;
        }
    }

}
