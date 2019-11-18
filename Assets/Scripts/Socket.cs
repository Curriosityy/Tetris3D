using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Socket
{
    Vector3 _socketPos;
    GameObject _tetrisPart;
    Socket _left, _right, _forward, _backward, _under;
    public Socket(Vector3 pos)
    {
        _socketPos = pos;
    }
    public void SetNeightbors(Socket left, Socket right, Socket forward, Socket backward, Socket under)
    {
        _left = left;
        _right = right;
        _forward = forward;
        _backward = backward;
        _under = under;
    }
    public GameObject TetrisPart{
        get
        {
            return _tetrisPart;
        }
        set
        {
            value.GetComponent<PartMover>().CurrentSocket = this;
            _tetrisPart = value;

        }
    }

    public Vector3 SocketPos
    {
        get
        {
            return _socketPos;
        }
    }

    public Socket Left { get => _left; set => _left = value; }
    public Socket Right { get => _right; set => _right = value; }
    public Socket Forward { get => _forward; set => _forward = value; }
    public Socket Backward { get => _backward; set => _backward = value; }
    public Socket Under { get => _under; set => _under = value; }

    public bool CheckTetrisSocket()
    {
        RaycastHit raycast;
        if (Physics.SphereCast(SocketPos, .4f, Vector3.forward, out raycast))
        {
            _tetrisPart = raycast.collider.gameObject;
            return true;
        }
        return false;
        
    }
}

