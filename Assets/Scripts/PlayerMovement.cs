using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("")]
    [SerializeField] PlayerToolSelectionAndUse playerTool;

    [Header("")]
    [SerializeField] float WalkingSpeed;

    bool isMovingUp;
    bool isMovingDown;
    bool isMovingLeft;
    bool isMovingRight;

    bool prevIsMovingUp;
    bool prevIsMovingDown;
    bool prevIsMovingLeft;
    bool prevIsMovingRight;

    [Header("")]
    public char direction;

    public bool isWalking2;


    void Start()
    {
        direction = 'S';
        prevIsMovingUp = isMovingUp;
        prevIsMovingDown = isMovingDown;
        prevIsMovingLeft = isMovingLeft;
        prevIsMovingRight = isMovingRight;
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
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }

        movement.Normalize();

        transform.Translate(movement * WalkingSpeed * Time.deltaTime);

    }
}
