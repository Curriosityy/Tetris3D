using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    PawnPooler _pool;
    List<Tetrimino> _tetriminos;
    BoardCreator _boardCreator;
    BattleManager bm;
    // Start is called before the first frame update
    void Start()
    {
        _tetriminos = new List<Tetrimino>();
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(2, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, -1, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, -1, 0), new Vector3(1, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, -1, 0), new Vector3(0, -1, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(-1, -1, 0), new Vector3(0, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(0, -1, 0) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, -1, 0), new Vector3(0, -1, 1) }));
        _tetriminos.Add(new Tetrimino(new Vector3[] { new Vector3(-1, -1, 0), new Vector3(0, -1, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 1) }));
        _boardCreator = FindObjectOfType<BoardCreator>();
        bm = FindObjectOfType<BattleManager>();
    }

    public TetrionInitializer SpawnPawn()
    {
        _pool = PawnPooler.Instance;
        if (_pool != null)
        {
            TetrionInitializer pawn = _pool.GetFromPool();
            Tetrimino randomTet = _tetriminos[Random.Range(0, _tetriminos.Count)];
            pawn.Initialize(randomTet.Pos);
            SettingUpInGraph(randomTet, pawn);
            pawn.transform.position = transform.position;
            bm.GetComponent<Animator>().SetTrigger("Spawned");
            return pawn;
        }
        return null;

    }
    void SettingUpInGraph(Tetrimino tetrimino,TetrionInitializer initializer)
    {
        Socket socket;
        int x = 3, y = 7, z = 3;
        for(int i=0;i<4;i++)
        {
            socket=_boardCreator.SocketLayers[y + (int)tetrimino.Pos[i].y][x + (int)tetrimino.Pos[i].x, z + (int)tetrimino.Pos[i].z];
            socket.TetrisPart = initializer.Parts[i];
        }

    }

}
