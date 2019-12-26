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
            if (!part.CanItMoveLeft())
            {
                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveLeft();
        }
        transform.Translate(Vector3.left);
        GetComponent<PawnShadow>().SetShadowPosition();
    }
    public void MoveRight()
    {

        foreach (var part in _parts)
        {
            if (!part.CanItMoveRight())
            {
                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveRight();
        }
        transform.Translate(Vector3.right);
        GetComponent<PawnShadow>().SetShadowPosition();
    }
    public void MoveForward()
    {

        foreach (var part in _parts)
        {
            if (!part.CanItMoveForward())
            {

                return;
            }
        }

        foreach (var part in _parts)
        {
            part.MoveForward();
        }
        transform.Translate(Vector3.forward);
        GetComponent<PawnShadow>().SetShadowPosition();
    }
    public void MoveBackward()
    {

        foreach (var part in _parts)
        {
            if (!part.CanItMoveBackward())
            {

                return;
            }
        }
        foreach (var part in _parts)
        {
            part.MoveBackward();
        }
        transform.Translate(Vector3.back);
        GetComponent<PawnShadow>().SetShadowPosition();
    }
    private void Collided()
    {
        PawnControler pc = FindObjectOfType<PawnControler>();
        FindObjectOfType<BattleManager>().GetComponent<Animator>().SetTrigger("Collided");
        GetComponent<PawnShadow>().DisableShadow();
    }
    public void Fall()
    {

        foreach (var part in _parts)
        {
            if (!part.CanItFall())
            {
                Collided();
                return;
            }
        }
        foreach (var part in _parts)
        {
            part.Fall();
        }
        transform.Translate(Vector3.down);
        GetComponent<PawnShadow>().SetShadowPosition();
    }
}
