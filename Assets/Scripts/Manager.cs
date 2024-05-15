using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Manager
{
    public static GameObject baseEntry;
    public static GameObject[] allEnemys;
    public static GameObject nearestEnemy;
    public static float distance;
    private static float nearestDistance = 1000000;

    private static void Start()
    {
        baseEntry = GameObject.Find("BaseEntry");
        allEnemys = GameObject.FindGameObjectsWithTag("enemy");
    }

    private static void FixedUpdate()
    {
        trackNearestEnemy();
    }

    private static GameObject trackNearestEnemy()
    {
        for (int i = 0; i < allEnemys.Length; i++)
        {
            distance = Vector2.Distance(baseEntry.transform.position, allEnemys[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestEnemy = allEnemys[i];
                nearestDistance = distance;
            }
        }

        return nearestEnemy;
    }

    public static void newEenemyHasSpawend()
    {
        allEnemys = new GameObject[GameObject.FindGameObjectsWithTag("enemy").Length];
        Array.Copy(GameObject.FindGameObjectsWithTag("enemy"), allEnemys, GameObject.FindGameObjectsWithTag("enemy").Length);
        Debug.Log(GameObject.FindGameObjectsWithTag("enemy").Length);
    }

}
