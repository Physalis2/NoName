using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private bool up;
    private bool down;
    private bool rigth;
    private bool left;

    private char lastKeyPressed = '0';
    private char lastDirektion = '0';



    private void movePlayer()
    {
        if (Input.GetKey(KeyCode.W))
        {
            up = true;
            lastKeyPressed = 'W';
        }
        if (!Input.GetKey(KeyCode.W) && iswalking())
        { 
            up = false;
            lastKeyPressed = checkForOtherKey('W');
        }

        if (Input.GetKey(KeyCode.S) )
        {
            down = true;
            lastKeyPressed = 'S';
        }
        if (!Input.GetKey(KeyCode.S) && iswalking())
        {
            down = false;
            lastKeyPressed = checkForOtherKey('S');
        }

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
            lastKeyPressed = 'A';
        }
        if (!Input.GetKey(KeyCode.A) && iswalking())
        {
            left = false;
            lastKeyPressed = checkForOtherKey('A');
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rigth = true;
            lastKeyPressed = 'D';
        }
        if (!Input.GetKey(KeyCode.D) && iswalking())
        {
            rigth = false;
            lastKeyPressed = checkForOtherKey('D');
        }
        Debug.Log(lastKeyPressed);
    }

    private bool iswalking()
    {
        if(up || down || left || rigth)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private char checkForOtherKey(char key)
    {
        if (up == true)
        {
            return 'W';
        }
        else if (down == true)
        {
            return 'S';
        }
        else if (left == true)
        {
            return 'A';
        }
        else if (rigth == true)
        {
            return 'D';
        }
        else if (lastKeyPressed == '0')
        {
            return '0';
        }
        else
        {
            return key;
        }
    }
}
