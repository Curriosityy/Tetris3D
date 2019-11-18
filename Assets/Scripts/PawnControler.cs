using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnControler : MonoBehaviour
{
    TetrionInitializer pawn;

    public TetrionInitializer Pawn
    {
        get
        {
            return pawn;
        }

        set
        {
            pawn = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pawn = FindObjectOfType<Spawner>().SpawnPawn();
    }



    // Update is called once per frame
    void Update()
    {
        if(pawn!=null)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {

                pawn.transform.Translate(Vector3.back);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                pawn.transform.Translate(Vector3.forward);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                pawn.transform.Translate(Vector3.left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                pawn.transform.Translate(Vector3.right);
            }
        }
    }
}
