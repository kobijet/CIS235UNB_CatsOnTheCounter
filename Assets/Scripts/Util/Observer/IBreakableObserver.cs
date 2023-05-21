using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBreakableObserver
{
    public void OnNotify(ObjectValuesEnum objectType);
}
