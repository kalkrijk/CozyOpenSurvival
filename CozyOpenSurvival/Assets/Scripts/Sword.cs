using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IRemoveable
{
    public void Remove()
    {
        Destroy(gameObject);
    }
}
