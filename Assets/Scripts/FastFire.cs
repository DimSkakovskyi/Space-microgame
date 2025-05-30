using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastFire : MonoBehaviour, IItem
{
    public static event Action OnFastFire;
    public void Collect()
    {
        OnFastFire.Invoke();
        Destroy(gameObject);
    }
}
