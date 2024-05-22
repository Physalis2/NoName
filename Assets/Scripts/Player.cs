using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float speed = 5;
    public GameObject[] projectiles;
    public GameObject selectedBullet;

    private void Start()
    {
        projectiles = Bullets.BulletScript.projectiles;
        selectedBullet = projectiles[0];
    }

    private void Update()
    {
        movePlayer();
        lookAtMouse();
        shoot();
    }

    private void movePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }

    private void lookAtMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f; // offsetting angel
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            spawnPrefab(selectedBullet);
        }
    }

    private void spawnPrefab(GameObject prefab)
    {
        Vector3 spawnPosition = transform.position;
        GameObject Bullet = Instantiate(prefab, spawnPosition, Quaternion.identity);
        Bullets bulletCs = Bullet.GetComponent<Bullets>();

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 direction = mousePosition - transform.position;

        bulletCs.direction = direction;

    }
}
