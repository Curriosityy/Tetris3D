using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class BoardCreator : MonoBehaviour
{
    int x = 8, y = 8, z = 8;
    [SerializeField]
    List<Socket[,]> _socketLayers;

    public List<Socket[,]> SocketLayers{ get { return _socketLayers; } }

    private void Awake()
    {
        _socketLayers = new List<Socket[,]>();
        for (int k = 0; k < y; k++)
        {
            _socketLayers.Add(new Socket[x, z]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < z; j++)
                {
                    _socketLayers[k][i, j] = new Socket(new Vector3((x / (2 * -1) + 1) + i, k, (z / (2 * -1) + 1) + j));
                }
            }
        }
        for (int k = 0; k < y; k++)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < z; j++)
                {
                    
                    _socketLayers[k][i, j].SetNeightbors(i > 0 ? _socketLayers[k][i - 1, j] : null,
                                                        i < x - 1 ? _socketLayers[k][i + 1, j] : null,
                                                        j > 0 ? _socketLayers[k][i, j - 1] : null,
                                                        j < z - 1 ? _socketLayers[k][i, j + 1] : null,
                                                        k > 0 ? _socketLayers[k - 1][i, j] : null);
                }
            }
        }


    }

    private void OnDrawGizmos()
    {
        int i = 0, j = 0;
        if(_socketLayers != null)
        {
            foreach (var layer in _socketLayers)
            {
                
                foreach(var socket in layer)
                {
                    Gizmos.color = Color.white;
                    if(socket.TetrisPart!=null)
                        Gizmos.DrawSphere(socket.SocketPos, 0.4f);
                    if (socket._left!=null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(socket.SocketPos, socket._left.SocketPos);
                    }
                    if (socket._right != null)
                    {
                        Gizmos.color = Color.black;
                        Gizmos.DrawLine(socket.SocketPos, socket._right.SocketPos);
                    }
                    if (socket._backward != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(socket.SocketPos, socket._backward.SocketPos);
                    }
                    if (socket._forward != null)
                    {
                        Gizmos.color = Color.cyan;
                        Gizmos.DrawLine(socket.SocketPos, socket._forward.SocketPos);
                    }
                    if (socket._under != null)
                    {
                        Gizmos.color = Color.yellow;
                        Gizmos.DrawLine(socket.SocketPos, socket._under.SocketPos);
                    }
                    Gizmos.color = Color.magenta;
                    Handles.Label(socket.SocketPos, "[" + i + "," + j + "]");
                    i++;
                    if((i%=8)==0)
                    {
                        j++;
                        j %= 8;
                    }
                }

            }
        }
    }
}
