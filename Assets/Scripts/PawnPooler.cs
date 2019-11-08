using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPooler : MonoBehaviour
{
    static PawnPooler instance;
    [SerializeField] TetrionInitializer pawn;
    Queue<TetrionInitializer> pool;
    private static bool isQuitting=false;

    [SerializeField] int initialPoolSize=10;
    Transform tetrisHolder;
    private static object _lock = new object();
    public static PawnPooler Instance
    {
        get
        {
            lock(_lock)
            {
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<PawnPooler>() as PawnPooler;
                    singletonObject.name = typeof(PawnPooler).ToString() + " (Singleton)";
                    instance.pawn = Resources.Load<TetrionInitializer>("Prefabs/TetrisPawn");
                }
            }
            return instance;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        if(instance!=null && instance!=this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);
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
