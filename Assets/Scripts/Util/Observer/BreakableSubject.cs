using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BreakableSubject : MonoBehaviour
{
    private List<IBreakableObserver> observers = new List<IBreakableObserver>();

    // Add observer to subject's observer list
    public void AddObserver(IBreakableObserver observer)
    {
        observers.Add(observer);
    }

    // Remove observer from subject's observer list
    public void RemoveObserver(IBreakableObserver observer)
    {
        observers.Remove(observer);
    }

    // Notify observer when subject performs an event
    protected void NotifyObservers(ObjectValuesEnum objectType)
    {
        observers.ForEach((observer) => {
            observer.OnNotify(objectType);
        });
    }
}
