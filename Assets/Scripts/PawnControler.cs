using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnControler : MonoBehaviour
{
    TetrionInitializer pawn;
    TetrisMover pawnMover;
    public TetrionInitializer Pawn
    {
        get
        {
            return pawn;
        }

        set
        {
            pawnMover = value.GetComponent<TetrisMover>();
            pawn = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Pawn = FindObjectOfType<Spawner>().SpawnPawn();
    }



    // Update is called once per frame
    void Update()
    {
        if(pawn!=null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                pawnMover.MoveBackward();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pawnMover.MoveForward();
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pawnMover.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pawnMover.MoveRight();
            }
        }
    }
}
