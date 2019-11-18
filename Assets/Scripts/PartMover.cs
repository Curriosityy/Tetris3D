using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartMover : MonoBehaviour
{
    Socket _currentSocket;

    public Socket CurrentSocket { get => _currentSocket; set => _currentSocket = value; }

    public bool IsCanFallDown()
    {
        return _currentSocket.Under.TetrisPart == null ? true : false;
    }
    public bool IsCanMoveLeft()
    {
        return _currentSocket.Left.TetrisPart == null ? true : false;
    }
    public bool IsCanMoveRight()
    {
        return _currentSocket.Right.TetrisPart == null ? true : false;
    }
    public bool IsCanMoveBackward()
    {
        return _currentSocket.Backward.TetrisPart == null ? true : false;
    }
    public bool IsCanMoveForward()
    {
        return _currentSocket.Forward.TetrisPart == null ? true : false;
    }
}
