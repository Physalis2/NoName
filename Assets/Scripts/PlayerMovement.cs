using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float WalkingSpeed;


    public bool isMovingUp;
    public bool isMovingDown;
    public bool isMovingLeft;
    public bool isMovingRight;

    private bool prevIsMovingUp;
    private bool prevIsMovingDown;
    private bool prevIsMovingLeft;
    private bool prevIsMovingRight;

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
        }
    }

    private void movePlayer2()
    {
        if (Input.GetKey(KeyCode.W))
        {
            PlayerAnimation.isWaling = true;

            if (Input.GetKey(KeyCode.D))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                transform.position += (Vector3.right + Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                transform.position += (Vector3.left + Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                transform.position += Vector3.up * WalkingSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            PlayerAnimation.isWaling = true;

            if (Input.GetKey(KeyCode.D))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                transform.position += (Vector3.right + -Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                transform.position += (Vector3.left + -Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                transform.position += -Vector3.up * WalkingSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            PlayerAnimation.isWaling = true;

            if (Input.GetKey(KeyCode.W))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                transform.position += (Vector3.right + Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                transform.position += (Vector3.right + -Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
                transform.position += Vector3.right * WalkingSpeed * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerAnimation.isWaling = true;

            if (Input.GetKey(KeyCode.W))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
                transform.position += (Vector3.left + Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
                transform.position += (Vector3.left + -Vector3.up).normalized * WalkingSpeed * Time.deltaTime;
            }
            else
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
                transform.position += Vector3.left * WalkingSpeed * Time.deltaTime;
            }
        }
        else
        {
            PlayerAnimation.isWaling = false;
        }
        Debug.Log(PlayerAnimation.isWaling);
    }

    private void movePlayer()
    {
        isMovingUp = Input.GetKey(KeyCode.W);
        isMovingDown = Input.GetKey(KeyCode.S);
        isMovingLeft = Input.GetKey(KeyCode.A);
        isMovingRight = Input.GetKey(KeyCode.D);

        if (!iswalking())
        {
            Debug.Log("HI");
            if (prevIsMovingUp) PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleBack);
            if (prevIsMovingDown) PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleFront);
            if (prevIsMovingLeft) PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleLeft);
            if (prevIsMovingRight) PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleRigth);
            else
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.IdleFront);
            }
        }
        else
        {
            if (prevIsMovingUp && !isMovingUp && isMovingUp == false)
            {
                if(isMovingDown)
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
            if (prevIsMovingDown && !isMovingDown && isMovingDown == false)
            {
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
            if (prevIsMovingLeft && !isMovingLeft && isMovingLeft == false)
            {
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
            if (prevIsMovingRight && !isMovingRight && isMovingRight == false)
            {
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
            if ((prevIsMovingUp && !isMovingUp) && isMovingUp == true)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkBack);
            }
            if ((prevIsMovingDown && !isMovingDown) && isMovingDown == true)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkFront);
            }
            if ((prevIsMovingLeft && !isMovingLeft) && isMovingLeft == true)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkLeft);
            }
            if ((prevIsMovingRight && !isMovingRight) && isMovingRight == true)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WalkRigth);
            }
        }

        prevIsMovingUp = isMovingUp;
        prevIsMovingDown = isMovingDown;
        prevIsMovingLeft = isMovingLeft;
        prevIsMovingRight = isMovingRight;

        Vector2 movement = Vector2.zero;
        if (isMovingUp)
        {
            movement += Vector2.up;
        }
        if (isMovingDown)
        {
            movement += Vector2.down;
        }
        if (isMovingLeft)
        {
            movement += Vector2.left;
        }
        if (isMovingRight)
        {
            movement += Vector2.right;
        }

        movement.Normalize();

        transform.Translate(movement * WalkingSpeed * Time.deltaTime);
    }

    private bool iswalking()
    {
        if(isMovingUp || isMovingDown || isMovingLeft || isMovingRight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
