using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Troop : Thing
{
    public GameObject target = null;
    public float range = 10;

    public void troopStart()
    {
        thingStart();
    }

    private void FixedUpdate()
    {
        if (target == null)
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
