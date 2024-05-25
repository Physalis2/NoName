using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    Player playerCS;
    Transform playerTR;


    float speed = 3f;
    float rotationSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCS = player.GetComponent<Player>();
        playerTR = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        lookAtPlayer();
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void lookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
