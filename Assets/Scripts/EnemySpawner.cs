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
        
    }

    public void nextWave(int wave)
    {
        for (int i = 0;i < wave;i++)
        {
            spawnEnemys(Enemy);
        }
    }

    public void spawnEnemys(GameObject prefab)
    {
        Instantiate(prefab, spawnPoints[UnityEngine.Random.Range(0,16)].transform.position, Quaternion.identity);
    }
}
