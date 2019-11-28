using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    Socket _currentSocket;
    public Socket CurrentSocket { get => _currentSocket; set => _currentSocket = value; }
}
