using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Thing
{
    [SerializeField] GameObject baseEntry = GameObject.Find("BaseEntry");
    private float speed = 1;

    void Start()
    {
        Manager.newEenemyHasSpawend();
    }
    void FixedUpdate()
    {
        moveToBase();
    }

    public void moveToBase() 
    {
        transform.position += (baseEntry.transform.position - transform.position).normalized * Time.deltaTime * speed;
    }

}
