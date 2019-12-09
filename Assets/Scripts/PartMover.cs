using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    Part _partInfo;
    private void Start()
    {
        _partInfo = GetComponent<Part>();
    }

    public void MoveLeft()
    {
        Move(_partInfo.CurrentSocket.Left);
        transform.Translate(Vector3.left);
    }
    public void MoveRight()
    {
        Move(_partInfo.CurrentSocket.Right);
        transform.Translate(Vector3.right);
    }

    public void MoveForward()
    {
        Move(_partInfo.CurrentSocket.Forward);
        transform.Translate(Vector3.forward);
    }

    public void MoveBackward()
    {
        Move(_partInfo.CurrentSocket.Backward);
        transform.Translate(Vector3.back);
    }
    public void Fall()
    {
        Move(_partInfo.CurrentSocket.Under);
        transform.Translate(Vector3.down);
    }

    private void Move(Socket direction)
    {
        if(_partInfo.CurrentSocket.TetrisPart==gameObject)
        {
            _partInfo.CurrentSocket.TetrisPart = null;
        }
        direction.TetrisPart = gameObject;
        _partInfo.CurrentSocket = direction;
    }

    public bool IsCanFall()
    {
        return IsCanMove(_partInfo.CurrentSocket.Under);
    }
    public bool IsCanMoveLeft()
    {
        return IsCanMove(_partInfo.CurrentSocket.Left);
    }
    public bool IsCanMoveRight()
    {
        return IsCanMove(_partInfo.CurrentSocket.Right);
    }
    public bool IsCanMoveBackward()
    {
        return IsCanMove(_partInfo.CurrentSocket.Backward);
    }
    public bool IsCanMoveForward()
    {
        return IsCanMove(_partInfo.CurrentSocket.Forward);
    }
    private bool IsCanMove(Socket dicertion)
    {
        if (dicertion == null)
        {
            return false;
        }
        if (dicertion.TetrisPart == null)
        {
            return true;
        }
        if (dicertion.TetrisPart.transform.parent == transform.parent)
        {
            return true;
        }
        return false;
    }
}
