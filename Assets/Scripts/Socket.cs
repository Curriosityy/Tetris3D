using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Socket
{
    Vector3 socketPos;
    GameObject tetrisPart;
    public Socket(Vector3 pos)
    {
        SocketPos = pos;
    }

    public GameObject TetrisPart{get;}

    public Vector3 SocketPos
    {
        get;
    }

    public bool CheckTetrisSocket()
    {
        RaycastHit raycast;
        if (Physics.SphereCast(SocketPos, .4f, Vector3.forward, out raycast))
        {
            tetrisPart = raycast.collider.gameObject;
            return true;
        }
        return false;
        
    }
}

