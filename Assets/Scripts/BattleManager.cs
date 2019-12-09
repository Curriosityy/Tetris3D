using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    Spawner _tetrisSpawner;
    PawnControler _tetrisControler;
    BoardMatcher _boardMatcher;
    LayerFaller _layerFaller;
    public Spawner TetrisSpawner { get => _tetrisSpawner; }
    public PawnControler Controler { get => _tetrisControler; }
    public BoardMatcher BoardMatcher { get => _boardMatcher; }
    public LayerFaller LayerFaller { get => _layerFaller; }

    void Start()
    {
        _tetrisSpawner = FindObjectOfType<Spawner>();
        _tetrisControler = FindObjectOfType<PawnControler>();
        _boardMatcher = FindObjectOfType<BoardMatcher>();
        _layerFaller = FindObjectOfType<LayerFaller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
