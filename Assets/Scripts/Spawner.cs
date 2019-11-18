using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PawnPooler pool;
    List<Tetrimino> tetriminos;
    Socket socket;
    // Start is called before the first frame update
    void Start()
    {
        tetriminos = new List<Tetrimino>();
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(3, 0, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(2, -1, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0), new Vector3(2, -1, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, -1, 0), new Vector3(1, -1, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(1, -1, 0) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0), new Vector3(1, -1, 1) }));
        tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1) }));
    }

    public TetrionInitializer SpawnPawn()
    {
        pool = PawnPooler.Instance;
        if (pool != null)
        {
            TetrionInitializer pawn = pool.GetFromPool();
            Tetrimino randomTet = tetriminos[Random.Range(0, tetriminos.Count)];
            pawn.Initialize(randomTet.Pos);
            pawn.transform.position = transform.position;
            return pawn;
        }
        return null;

    }

}
