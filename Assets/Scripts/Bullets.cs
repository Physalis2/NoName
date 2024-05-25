using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [SerializeField] public GameObject[] projectiles;

    public static Bullets BulletScript;

    private void Awake()
    {
        BulletScript = this;
    }

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
