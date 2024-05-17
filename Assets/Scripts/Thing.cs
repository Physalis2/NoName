using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Thing : MonoBehaviour
{
    public GameObject baseEntry = Manager.baseEntry;
    public float speed = 1f;
    public float health;

    public void thingStart() 
    {
        if (baseEntry == null) { baseEntry = Manager.baseEntry; }
    }   
}
