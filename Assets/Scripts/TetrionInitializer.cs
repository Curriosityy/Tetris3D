using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrionInitializer : MonoBehaviour
{
    [SerializeField] List<GameObject> _parts;

    bool _isInitialized = false;
    PawnPooler _pool;
    bool _collided = false;
    public bool IsInitialized
    {
        get
        {
            return _isInitialized;
        }
    }

    public List<GameObject> Parts { get { return _parts; } }

    public void Initialize(Vector3[] localPosition)
    {

        if (localPosition.Length != _parts.Count)
        {
            Debug.LogError("wrong number of localPosition-Initialize-TetrionInitializer");

            return;
        }
        _isInitialized = true;
        for (int i = 0; i < _parts.Count; i++)
        {
            _parts[i].transform.position = localPosition[i];
            _parts[i].SetActive(true);
        }
        gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void OnDisable()
    {
        _isInitialized = false;
        _pool = PawnPooler.Instance;
        if (_pool != null)
        {
            PawnPooler.Instance.AddToPool(this);
        }
    }
}
