using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager ManagerScript;
    public static int wave = 1;
    private float waveCouldown = 3f;


    private void Awake()
    {
        ManagerScript = this;
    }

    private void Update()
    {
        waveCycle();
    }

    private void waveCycle()
    {
        if (Time.time > wave/3 * waveCouldown)
        {
            Debug.Log(wave);
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().nextWave(wave);
            wave++;
        }
    }
}
