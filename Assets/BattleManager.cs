using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    Spawner _tetrisSpawner;
    PawnControler _tetrisControler;
    public Spawner TetrisSpawner { get => _tetrisSpawner; }
    public PawnControler Controler { get => _tetrisControler; }

    void Start()
    {
        _tetrisSpawner = FindObjectOfType<Spawner>();
        _tetrisControler = FindObjectOfType<PawnControler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
