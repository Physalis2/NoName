using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float WalkingSpeed;

    [Header("")]
    public bool isMovingUp;
    public bool isMovingDown;
    public bool isMovingLeft;
    public bool isMovingRight;

    [Header("")]
    public bool prevIsMovingUp;
    public bool prevIsMovingDown;
    public bool prevIsMovingLeft;
    public bool prevIsMovingRight;

    [Header("")]
    public bool isWalking2;

    void Start()
    {
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

        Debug.Log("stand");

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
        }
        if (!prevIsMovingDown && isMovingDown)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
        }
        if (!prevIsMovingLeft && isMovingLeft)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
        }
        if (!prevIsMovingRight && isMovingRight)
        {
            PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
        }
    }

    private void checkForBoolChangeToFalse()
    {
        if (prevIsMovingUp && !isMovingUp)
        {
            if(!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleBack);
            }

            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
            }
        }
        if (prevIsMovingDown && !isMovingDown)
        {
            if (!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleFront);
            }

            if (isMovingUp)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
            }
        }
        if (prevIsMovingLeft && !isMovingLeft)
        {
            if (!iswalking())
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleLeft);
            }

            if (isMovingUp)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
            }
            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
            }
            if (isMovingRight)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
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
            }
            if (isMovingDown)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
            }
            if (isMovingLeft)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
            }
        }
    }
}
