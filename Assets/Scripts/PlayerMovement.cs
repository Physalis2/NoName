using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
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
        isWalking2 = iswalking();
    }
    private void FixedUpdate()
    {
        if (!TimerCS.istPausiert)
        {
            movePlayer();
            animateMovement();
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

    private void animateMovement()
    {
        isMovingUp = Input.GetKey(KeyCode.W);
        isMovingDown = Input.GetKey(KeyCode.S);
        isMovingLeft = Input.GetKey(KeyCode.A);
        isMovingRight = Input.GetKey(KeyCode.D);

        checkForBoolChangeToTrue();
        checkForBoolChangeToFalse();

        prevIsMovingUp = isMovingUp;
        prevIsMovingDown = isMovingDown;
        prevIsMovingLeft = isMovingLeft;
        prevIsMovingRight = isMovingRight;
    }

    private void checkForBoolChangeToTrue()
    {
        if (!prevIsMovingUp && isMovingUp)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
            direction = 'W';
        }
        if (!prevIsMovingDown && isMovingDown)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
            direction = 'S';
        }
        if (!prevIsMovingLeft && isMovingLeft)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
            direction = 'A';
        }
        if (!prevIsMovingRight && isMovingRight)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
            direction = 'D';
        }
    }

    private void checkForBoolChangeToFalse()
    {
        if (prevIsMovingUp && !isMovingUp)
        {
            if(!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleBack);
                direction = 'W';
            }

            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                direction = 'S';
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                direction = 'A';
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingDown && !isMovingDown)
        {
            if (!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleFront);
                direction = 'S';
            }

            if (isMovingUp)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                direction = 'W';
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                direction = 'A';
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingLeft && !isMovingLeft)
        {
            if (!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleLeft);
                direction = 'A';
            }

            if (isMovingUp)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                direction = 'W';
            }
            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                direction = 'S';
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingRight && !isMovingRight)
        {
            if (!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleRigth);
            }

            if (isMovingUp)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                direction = 'W';
            }
            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                direction = 'S';
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                direction = 'A';
            }
        }
    }
}
