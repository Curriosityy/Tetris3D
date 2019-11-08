using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrionInitializer : MonoBehaviour
{

    [SerializeField] GameObject cube;
    [SerializeField] int partsSize=4;
    GameObject[] parts;
    bool isInitialized = false;

    public bool IsInitialized
    {
        get
        {
            return isInitialized;
        }
    }

    private void Awake()
    {
        parts = new GameObject[partsSize];
    }
    void Start()
    {
        for (int i = 0; i < partsSize; i++)
        {
            parts[i] = Instantiate(cube, Vector3.zero, Quaternion.identity, transform);
        }
    }
    public void Initialize(Vector3[] localPosition)
    {
        if (localPosition.Length!= partsSize)
        {
            Debug.LogError("wrong number of localPosition-Initialize-TetrionInitializer");

            return;
        }
        isInitialized = true; 
        for(int i=0;i<partsSize; i++)
        {
            parts[i].transform.position = localPosition[i];
        }
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        isInitialized = false;
        PawnPooler.Instance.AddToPool(this);
    }
}
