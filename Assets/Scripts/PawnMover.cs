using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMover : MonoBehaviour
{
    List<PartMover> _parts;
    // Start is called before the first frame update
    void Start()
    {
        _parts = new List<PartMover>();
        GetComponent<Tetrion>().Parts.ForEach(part => { _parts.Add(part.GetComponent<PartMover>()); });
    }

    public void MoveLeft()
    {
        foreach (var part in _parts)
        {
            if (!part.IsCanMoveLeft())
            {
                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveLeft();
        }
    }
    public void MoveRight()
    {

        foreach (var part in _parts)
        {
            if (!part.IsCanMoveRight())
            {
                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveRight();
        }
    }
    public void MoveForward()
    {

        foreach (var part in _parts)
        {
            if (!part.IsCanMoveForward())
            {

                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveForward();
        }
    }
    public void MoveBackward()
    {

        foreach (var part in _parts)
        {
            if (!part.IsCanMoveBackward())
            {

                return;
            }
        }
        foreach (var part in _parts)
        {
            part.MoveBackward();
        }
    }
    private void Collided()
    {
        PawnControler pc = FindObjectOfType<PawnControler>();
        FindObjectOfType<BattleManager>().GetComponent<Animator>().SetTrigger("Collided");
    }
    public void Fall()
    {

        foreach (var part in _parts)
        {
            if (!part.IsCanFall())
            {
                Collided();
                return;
            }
        }
        foreach (var part in _parts)
        {
            part.Fall();
        }
    }
}
