﻿using System.Collections;
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
    }
    public void MoveRight()
    {
        Move(_partInfo.CurrentSocket.Right);
    }

    public void MoveForward()
    {
        Move(_partInfo.CurrentSocket.Forward);
    }

    public void MoveBackward()
    {
        Move(_partInfo.CurrentSocket.Backward);
    }
    public void Fall()
    {
        Move(_partInfo.CurrentSocket.Under);
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

    public bool CanItFall()
    {
        return CanItMove(_partInfo.CurrentSocket.Under);
    }
    public bool CanItMoveLeft()
    {
        return CanItMove(_partInfo.CurrentSocket.Left);
    }
    public bool CanItMoveRight()
    {
        return CanItMove(_partInfo.CurrentSocket.Right);
    }
    public bool CanItMoveBackward()
    {
        return CanItMove(_partInfo.CurrentSocket.Backward);
    }
    public bool CanItMoveForward()
    {
        return CanItMove(_partInfo.CurrentSocket.Forward);
    }
    public bool CanItMove(Socket dicertion)
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
