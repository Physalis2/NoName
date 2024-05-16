using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Troop : Thing
{
    GameObject target = null;
    public float range = 10;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (target = null)
        {
            target = waitingForEnemy();
        }
        else
        {
            Debug.Log(Vector2.Distance(transform.position, target.transform.position));
        }
    }

    public GameObject waitingForEnemy()
    {
        GameObject obj = null;

        if (Manager.distance <= range)
        {
            obj = Manager.nearestEnemy;
        }
        return obj;
    }
}
