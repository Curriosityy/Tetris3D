using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPooler : Singleton<PawnPooler>
{
    [SerializeField] TetrionInitializer pawn;
    Queue<TetrionInitializer> pool;
    private static bool isQuitting=false;

    [SerializeField] int initialPoolSize=10;
    Transform tetrisHolder;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance!=null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
        pawn = Resources.Load<TetrionInitializer>("Prefabs/TetrisPawn");
        pool = new Queue<TetrionInitializer>();
        tetrisHolder = new GameObject("tetrisHolder").transform;

    }
    private void Start()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }
    }
    public TetrionInitializer GetFromPool()
    {
        Debug.Log(pool.Count);
        if (pool.Count==0)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }
        return pool.Dequeue();
    }

    public void AddToPool(TetrionInitializer objectToPooling)
    {
        pool.Enqueue(objectToPooling);
    }
}
