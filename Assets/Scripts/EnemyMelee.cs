using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    [SerializeField] GameObject baseEntry;
    private float speed = 1;


    void Start()
    {
        Manager.newEenemyHasSpawend();
        baseEntry = GameObject.Find("BaseEntry");

    }

    void FixedUpdate()
    {
        transform.position += (baseEntry.transform.position - transform.position).normalized * Time.deltaTime * speed;
    }

}