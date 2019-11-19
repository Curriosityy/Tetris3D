using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    Socket _currentSocket;

    public Socket CurrentSocket { get => _currentSocket; set => _currentSocket = value; }

    public void MoveLeft()
    {
        Move(_currentSocket.Left);
    }
    public void MoveRight()
    {
        Move(_currentSocket.Right);
    }

    public void MoveForward()
    {
        Move(_currentSocket.Forward);
    }

    public void MoveBackward()
    {
        Move(_currentSocket.Backward);
    }
    public void Fall()
    {
        Move(_currentSocket.Under);
    }

    private void Move(Socket direction)
    {
        _currentSocket.TetrisPart = null;
        direction.TetrisPart = gameObject;
    }

    public bool IsCanFall()
    {
        return IsCanMove(_currentSocket.Under);
    }
    public bool IsCanMoveLeft()
    {
        return IsCanMove(_currentSocket.Left);
    }
    public bool IsCanMoveRight()
    {
        return IsCanMove(_currentSocket.Right);
    }
    public bool IsCanMoveBackward()
    {
        return IsCanMove(_currentSocket.Backward);
    }
    public bool IsCanMoveForward()
    {
        return IsCanMove(_currentSocket.Forward);
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
