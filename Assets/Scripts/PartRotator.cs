using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartRotator : MonoBehaviour
{
    bool isInitialized = false;
    float _r, _phi, _theta;

    public float R { get => _r; set => _r = value; }
    public float Phi { get => _phi; set => _phi = value; }
    public float Theta { get => _theta; set => _theta = value; }

    // Start is called before the first frame update

    public void Initialize(Vector3 pos)
    {
        _r = Mathf.Sqrt(Mathf.Pow(pos.x, 2) + Mathf.Pow(pos.y, 2) + Mathf.Pow(pos.z, 2));
        _theta = pos.x == 0 ? 0 : Mathf.Acos(pos.z / pos.x);
        _phi = _r == 0 ? 0 : Mathf.Atan(pos.y / _r);
        isInitialized = true;
    }

    public Vector3 CountCartesian(float r, float phi, float theta)
    {
        return new Vector3(r * Mathf.Sin(theta) * Mathf.Cos(phi), r * Mathf.Sin(theta) * Mathf.Sin(phi), r * Mathf.Cos(theta));
    }

    public Vector2 Rotate(Vector2 phiAndTheta)
    {
        return new Vector2(_phi + phiAndTheta.x, phiAndTheta.y + _theta);
    }
    private bool IsNewPositionInBoard(Vector3 newPosition)
    {
        return newPosition.x >= 0 && newPosition.x < GameManager.x && newPosition.y >= 0 && newPosition.y < GameManager.y+4 && newPosition.z >= 0 && newPosition.z < GameManager.z;
    }
    private bool IsNewPositionSocketEmpty(Vector3 newPosition)
    {
        Socket socket = FindObjectOfType<BoardCreator>().SocketLayers[(int)newPosition.y][(int)newPosition.x, (int)newPosition.z];
        if(socket.TetrisPart==null)
        {
            return true;
        }
        if(socket.TetrisPart==gameObject || socket.TetrisPart.transform.parent==gameObject.transform.parent)
        {
            return true;
        }
        return false;
    }
    public bool isCanRotate(Vector2 phiAndTheta)
    {
        Vector2 newSpherical = Rotate(phiAndTheta);
        Vector3 cartesian = CountCartesian(_r, newSpherical.x, newSpherical.y);
        Socket socket = GetComponent<PartMover>().CurrentSocket;
        cartesian.x += socket.XInArray;
        cartesian.y += socket.Layer;
        cartesian.z += socket.YInArray;
        if (IsNewPositionInBoard(cartesian) && IsNewPositionSocketEmpty(cartesian))
        {
            phiAndTheta = newSpherical;
            return true;
        }
        return false;
    }
    private void OnDisable()
    {
        isInitialized = false;
    }
}
