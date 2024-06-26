using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Transform playerTR;

    float speed = 3f;
    float rotationSpeed = 3f;

    void Start()
    {
        player = GameObject.Find("Player");
        playerTR = player.transform;
    }

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
