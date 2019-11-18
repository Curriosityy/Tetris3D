using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PawnPooler _pool;
    List<Tetrimino> _tetriminos;
    BoardCreator _boardCreator;
    // Start is called before the first frame update
    void Start()
    {
        _tetriminos = new List<Tetrimino>();
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(3, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(2, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0), new Vector3(2, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, -1, 0), new Vector3(1, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0), new Vector3(1, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0), new Vector3(1, -1, 1) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(0, -1, 0), new Vector3(1, -1, 0), new Vector3(1, 0, 0), new Vector3(1, 0, 1) }));
        _boardCreator = FindObjectOfType<BoardCreator>();
    }

    public TetrionInitializer SpawnPawn()
    {
        _pool = PawnPooler.Instance;
        if (_pool != null)
        {
            TetrionInitializer pawn = _pool.GetFromPool();
            Tetrimino randomTet = _tetriminos[Random.Range(0, _tetriminos.Count)];
            pawn.Initialize(randomTet.Pos);
            pawn.transform.position = transform.position;
            SettingUpInGraph(randomTet, pawn);
            return pawn;
        }
        return null;

    }
    private void SettingUpInGraph(Tetrimino tetrimino,TetrionInitializer initializer)
    {
        int x = 3, y = 7, z = 3;
        for(int i=0;i<4;i++)
        {
            _boardCreator.SocketLayers[y + (int)tetrimino.Pos[i].y][x + (int)tetrimino.Pos[i].x, z + (int)tetrimino.Pos[i].z].TetrisPart=initializer.Parts[i];
        }
    }

}
