using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] GameObject baseEntry;
    GameObject Target;
    private float speed = 1; 

    void Start()
    {
        baseEntry = GameObject.Find("BaseEntry");
        Debug.Log("melee all setup");
        
    }

    void FixedUpdate()
    {

    }
}
