using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    Socket _currentSocket;

    public Socket CurrentSocket { get => _currentSocket; set => _currentSocket = value; }

    public bool IsCanFallDown()
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
        if (dicertion.TetrisPart.GetComponentInParent<GameObject>() == GetComponentInParent<GameObject>())
        {
            return true;
        }
        return false;
    }
}
