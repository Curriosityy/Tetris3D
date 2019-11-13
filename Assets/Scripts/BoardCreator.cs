using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BoardCreator : MonoBehaviour
{
    int x = 8, y = 6, z = 8;
    [SerializeField]
    List<Socket[,]> socketLayers;

    public List<Socket[,]> SocketLayers{get;}

    private void Awake()
    {
        socketLayers = new List<Socket[,]>();
        for (int k = 0; k < y; k++)
        {
            socketLayers.Add(new Socket[x, z]);
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < z; j++)
                {
                    socketLayers[k][i,j] = new Socket(new Vector3((x / 2 * -1 + 1) + i, k, (z / 2 * -1 + 1) + j));
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
       
        if(socketLayers != null)
        {
            foreach (var layer in socketLayers)
            {
                foreach(var socket in layer)
                {
                    Gizmos.DrawSphere(socket.SocketPos, 0.4f);
                }
            }
        }
    }
}
