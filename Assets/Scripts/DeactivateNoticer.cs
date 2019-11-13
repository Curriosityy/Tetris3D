using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateNoticer : MonoBehaviour,ISubject
{
    IObserver _observer;

    public void Attach(IObserver observer)
    {
        _observer = observer;
    }

    public void Detach(IObserver observer)
    {
        _observer = null;
    }

    public void Notify()
    {
        _observer.UpdateObserver();
    }

    private void OnDisable()
    {
        Notify();
    }
}
