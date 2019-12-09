using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillLayer : MonoBehaviour
{
    [SerializeField]
    GameObject part;
    Transform testContainer;
    // Update is called once per frame
    private void Start()
    {
        testContainer = new GameObject("testContainer").transform;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            var layer = FindObjectOfType<BoardCreator>().SocketLayers[0];
            foreach(var socket in layer)
            {
                if(socket.TetrisPart==null)
                    socket.TetrisPart = Instantiate(part,socket.SocketPos,Quaternion.identity,testContainer);
            }
        }
    }
}
