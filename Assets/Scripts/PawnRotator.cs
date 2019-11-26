using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class PawnRotator : MonoBehaviour
{
    List<PartRotator> _parts;
    Part _rootPart;
    List<Socket[,]> _layers;
    // Start is called before the first frame update
    void Start()
    {

        _parts = new List<PartRotator>();
        GetComponent<TetrionInitializer>().Parts.ForEach(part =>
        {
            _parts.Add(part.GetComponent<PartRotator>());
        });
        _layers = FindObjectOfType<BoardCreator>().SocketLayers;

    }


    public void Rotate(float phi, float theta)
    {
        
    }

    public void RotateLeft()
    {
        Rotate(0, Mathf.PI / 2);
    }
    public void RotateUp()
    {
        Rotate(Mathf.PI / 2, 0);
    }
    public void RotateRight()
    {
        Rotate(0, -Mathf.PI / 2);
    }
    public void RotateDown()
    {
        Rotate(-Mathf.PI / 2, 0);
    }
}
