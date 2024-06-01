using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float WalkingSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!TimerCS.istPausiert)
        {
            movePlayer();

        }
    }

    private void movePlayer()
    {

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * WalkingSpeed * Time.deltaTime;
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -Vector3.up * WalkingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * WalkingSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * WalkingSpeed * Time.deltaTime;
        }
    }
}
