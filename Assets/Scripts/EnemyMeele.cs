using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeele : MonoBehaviour
{

    [SerializeField] GameObject baseEntry;
    private float speed = 1;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.position = (baseEntry.transform.position - transform.position) * Time.deltaTime * speed;
    }
}
