using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float speed = 5;
    private float rotationSpeed = 180;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 rotate = new Vector3 (0, 0, 1) * rotationSpeed * Time.deltaTime ;
            transform.Rotate(-rotate);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 rotate = new Vector3(0, 0, 1)* rotationSpeed * Time.deltaTime;
            transform.Rotate(rotate);
        }
    }

}
