using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] GameObject baseEntry;
    GameObject nearestEnemy;
    private float speed = 1; 
    float länge = 0;
    List<GameObject> enemyList = new List<GameObject>();

    void Start()
    {
        baseEntry = GameObject.Find("BaseEntry");
        Debug.Log("melee all setup");
        
    }

    void FixedUpdate()
    {

        if (enemyList.Count > 0) 
        {
            Debug.Log(trackNearestEnemy().name);
        }
    }

    private GameObject trackNearestEnemy()
    {
        foreach (GameObject enemy in enemyList)
        {
            if (länge <= (baseEntry.transform.position - enemy.transform.position).sqrMagnitude)
            {
                nearestEnemy = enemy;
                länge = (baseEntry.transform.position - enemy.transform.position).sqrMagnitude;
            }
        }
        return nearestEnemy;
    }

    private void enterdVision(GameObject add)
    {
        enemyList.Add(add);
    }

    private void leftVision(GameObject minus)
    {
        enemyList.Remove(minus);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi2");
        if (!other.CompareTag("enemy"))
        {
            return;
        }
        Debug.Log("Hi3");
        enterdVision(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Hi-2");
        if (!other.CompareTag("enemy"))
        {
            return;
        }
        Debug.Log("Hi-3");
        leftVision(other.gameObject);
    }
}
