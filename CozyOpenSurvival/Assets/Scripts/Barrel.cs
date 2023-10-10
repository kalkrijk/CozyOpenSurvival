using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour, IRemoveable
{
    public event EventHandler OnBarrelObliderated;
    public void Remove()
    {
        Destroy(gameObject);
        Debug.Log("Barrel Obliderated");
        OnBarrelObliderated?.Invoke(this, EventArgs.Empty);
    }
}
