using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisMover : MonoBehaviour
{
    List<PartMover> _parts;
    // Start is called before the first frame update
    void Start()
    {
        _parts = new List<PartMover>();
        GetComponent<TetrionInitializer>().Parts.ForEach(part=> { _parts.Add(part.GetComponent<PartMover>()); });
    }

    public void MoveLeft()
    {
        bool canMove = true;
        foreach(var part in _parts)
        {
            if(!part.IsCanMoveLeft())
            {
                canMove = false;
                break;
            }
        }
        if(canMove)
        {
            foreach(var part in _parts)
            {
                part.MoveLeft();
            }
            transform.Translate(Vector3.left);
        }
    }
    public void MoveRight()
    {
        bool canMove = true;
        foreach (var part in _parts)
        {
            if (!part.IsCanMoveRight())
            {
                canMove = false;
                break;
            }
        }
        if (canMove)
        {
            foreach (var part in _parts)
            {
                part.MoveRight();
            }
            transform.Translate(Vector3.right);
        }
    }
    public void MoveForward()
    {
        bool canMove = true;
        foreach (var part in _parts)
        {
            if (!part.IsCanMoveForward())
            {
                canMove = false;
                break;
            }
        }
        if (canMove)
        {
            foreach (var part in _parts)
            {
                part.MoveForward();
            }
            transform.Translate(Vector3.forward);
        }
    }
    public void MoveBackward()
    {
        bool canMove = true;
        foreach (var part in _parts)
        {
            if (!part.IsCanMoveBackward())
            {
                canMove = false;
                break;
            }
        }
        if (canMove)
        {
            foreach (var part in _parts)
            {
                part.MoveBackward();
            }
            transform.Translate(Vector3.back);
        }
    }

    public void Fall()
    {
        bool canMove = true;
        foreach (var part in _parts)
        {
            if (!part.IsCanFall())
            {
                canMove = false;
                break;
            }
        }
        if (canMove)
        {
            foreach (var part in _parts)
            {
                part.Fall();
            }
            transform.Translate(Vector3.down);
        }
    }
}
