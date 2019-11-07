using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnPooler : MonoBehaviour
{
    private static PawnPooler instance;
    [SerializeField] TetrionInitializer pawn;
    Queue<TetrionInitializer> pool;
    [SerializeField] int initialPoolSize=10;
    Transform tetrisHolder;

    public static PawnPooler Instance
    {
        get
        {
            if(instance==null)
            {
                var singletonObject = new GameObject();
                instance = singletonObject.AddComponent<PawnPooler>();
                singletonObject.name = typeof(PawnPooler).ToString() + " (Singleton)";
                DontDestroyOnLoad(singletonObject);
            }
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        pool = new Queue<TetrionInitializer>();
        tetrisHolder = new GameObject("tetrisHolder").transform;
        for(int i=0;i<initialPoolSize;i++)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }

    }
    public TetrionInitializer GetFromPool()
    {
        if(pool.Count==0)
        {
            pool.Enqueue(Instantiate(pawn, tetrisHolder));
        }
        return pool.Dequeue();
    }

    public void AddToPool(TetrionInitializer objectToPooling)
    {
        pool.Enqueue(objectToPooling);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
