using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPooler : Singleton<PawnPooler>
{
    [SerializeField] Tetrion pawn;
    Queue<Tetrion> pool;
    private static bool isQuitting=false;

    [SerializeField] int initialPoolSize=10;
    Transform tetrisHolder;

    // Start is called before the first frame update
    void Awake()
    {
        pawn = Resources.Load<Tetrion>("Prefabs/TetrisPawn");
        pool = new Queue<Tetrion>();
        tetrisHolder = new GameObject("tetrisHolder").transform;
        for (int i = 0; i < initialPoolSize; i++)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }

    }
    public Tetrion GetFromPool()
    {
        Debug.Log(pool.Count);
        if (pool.Count==0)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }
        return pool.Dequeue();
    }

    public void AddToPool(Tetrion objectToPooling)
    {
        pool.Enqueue(objectToPooling);
    }
}
