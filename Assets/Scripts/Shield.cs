using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour, IItem
{
    public static event Action OnShieldActivate;
    public void Collect()
    {
        OnShieldActivate.Invoke();
        Destroy(gameObject);
    }
}
