using System;
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
    [SerializeField] char direction;

    void Start()
    {
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
            if (playerTool.usingTool)
            {

            }
            else
            {
                movePlayer();
                sendAnimationEvents();
            }
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

    //  -----------------------------------------

    public event EventHandler<animationMovementArgs> animationMovement;

    public class animationMovementArgs : EventArgs
    {
        public bool isWalking;
        public char direction;
    }



    public void sendAnimationEvents()
    {
        isMovingUp = Input.GetKey(KeyCode.W);
        isMovingDown = Input.GetKey(KeyCode.S);
        isMovingLeft = Input.GetKey(KeyCode.A);
        isMovingRight = Input.GetKey(KeyCode.D);

        checkForBoolChangeToTrue();
        checkForBoolChangeToFalse();

        animationMovement?.Invoke(this, new animationMovementArgs { isWalking = iswalking(), direction = direction });

        prevIsMovingUp = isMovingUp;
        prevIsMovingDown = isMovingDown;
        prevIsMovingLeft = isMovingLeft;
        prevIsMovingRight = isMovingRight;
    }

    private bool iswalking()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }

    private void checkForBoolChangeToTrue()
    {
        if (!prevIsMovingUp && isMovingUp)
        {
            direction = 'W';
        }
        if (!prevIsMovingDown && isMovingDown)
        {
            direction = 'S';
        }
        if (!prevIsMovingLeft && isMovingLeft)
        {
            direction = 'A';
        }
        if (!prevIsMovingRight && isMovingRight)
        {
            direction = 'D';
        }
    }

    private void checkForBoolChangeToFalse()
    {
        if (prevIsMovingUp && !isMovingUp)
        {
            if (!iswalking())
            {
                direction = 'W';
            }

            if (isMovingDown)
            {
                direction = 'S';
            }
            if (isMovingLeft)
            {
                direction = 'A';
            }
            if (isMovingRight)
            {
                direction = 'D';
            }
        }
        if (prevIsMovingDown && !isMovingDown)
        {
            if (!iswalking())
            {
                direction = 'S';
            }

            if (isMovingUp)
            {
                direction = 'W';
            }
            if (isMovingLeft)
            {
                direction = 'A';
            }
            if (isMovingRight)
            {
                direction = 'D';
            }
        }
        if (prevIsMovingLeft && !isMovingLeft)
        {
            if (!iswalking())
            {
                direction = 'A';
            }

            if (isMovingUp)
            {
                direction = 'W';
            }
            if (isMovingDown)
            {
                direction = 'S';
            }
            if (isMovingRight)
            {
                direction = 'D';
            }
        }
        if (prevIsMovingRight && !isMovingRight)
        {
            if (!iswalking())
            {
            }

            if (isMovingUp)
            {
                direction = 'W';
            }
            if (isMovingDown)
            {
                direction = 'S';
            }
            if (isMovingLeft)
            {
                direction = 'A';
            }
        }
    }
}
