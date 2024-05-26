using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private void Start()
    {
        speed = 10f;
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        transform.position += (direction).normalized * speed * Time.deltaTime;
    }
}
