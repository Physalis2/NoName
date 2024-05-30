using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject Enemy;
    
    void Start()
    {
        spawnPoints = (GameObject[])spawnerArray().Clone();
    }

    private GameObject[] spawnerArray()
    {
        int childCount = gameObject.transform.childCount;
        GameObject[] points = new GameObject[childCount];


        for (int i = 0; i < childCount; i++)
        {
            points[i] = gameObject.transform.GetChild(i).gameObject;
        }
        return points;
    }

    void Update()
    {
        wavesSpawn();
    }


    int wave = 1;
    float waveCouldown = 3f;

    public void wavesSpawn()
    {
        if (TimerCS.elapsedTime > waveCouldown * (wave -1))
        {
            for (int i = 0; i < wave; i++)
            {
                spawnEnemys(Enemy);
            }
            wave++;
        }
    }

    public void spawnEnemys(GameObject prefab)
    {
        Vector3 randomV3 = new Vector3(UnityEngine.Random.Range(-5f,5), UnityEngine.Random.Range(-5f,5),0);
        Instantiate(prefab, spawnPoints[UnityEngine.Random.Range(0,16)].transform.position + randomV3, Quaternion.identity);
    }
}
