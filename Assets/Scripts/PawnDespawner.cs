using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnDespawner : MonoBehaviour,IObserver
{
    int counter = 0;
    private void Awake()
    {
        DeactivateNoticer[] dn = gameObject.GetComponentsInChildren<DeactivateNoticer>();
        foreach(var subject in dn)
        {
            subject.Attach(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateObserver()
    {
        if(++counter==4)
        {
            PawnPooler.Instance.AddToPool(GetComponent<TetrionInitializer>());
            gameObject.SetActive(false);
        }
    }
}
