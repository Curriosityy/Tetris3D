using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Tetrimino
{
    Vector3[] pos;
    public Vector3[] Pos
    {
        get
        {
            return pos;
        }
    }
    public Tetrimino(Vector3[] positions)
    {
        pos = positions;
    }
    public Tetrimino(Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4)
    {
        pos = new Vector3[4];
        pos[0] = pos1;
        pos[1] = pos2;
        pos[2] = pos3;
        pos[3] = pos4;
    }


}

