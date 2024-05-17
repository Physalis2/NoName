using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Thing
{
    void Start()
    {
        thingStart();
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
