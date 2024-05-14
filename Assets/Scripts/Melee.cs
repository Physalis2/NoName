using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    [SerializeField] GameObject baseEntry;
    private float speed = 1;
    private CircleCollider2D range;
    private CircleCollider2D visibility;


    void Start()
    {
        baseEntry = GameObject.Find("BaseEntry");
        range = transform.Find("Range").GetComponent<CircleCollider2D>();
        visibility = transform.Find("Visibility").GetComponent<CircleCollider2D>();
        Debug.Log("melee all setup");
        
    }

    void FixedUpdate()
    {
        
    }

    public void EnemyInVision(GameObject)
    {

    }

}
