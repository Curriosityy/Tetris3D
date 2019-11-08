using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrionInitializer : MonoBehaviour
{
    [SerializeField] GameObject[] parts;
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
    }
    void Start()
    {
       
    }

    public void Initialize(Vector3[] localPosition)
    {

        if (localPosition.Length!= parts.Length)
        {
            Debug.LogError("wrong number of localPosition-Initialize-TetrionInitializer");

            return;
        }
        isInitialized = true;
        for (int i=0;i< parts.Length; i++)
        {
            parts[i].transform.position = localPosition[i];
            parts[i].SetActive(true);
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
