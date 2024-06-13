using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

class PlayerMovement : MonoBehaviour
{
    private void Awake()
    {
        
    }

    void Start()
    {

    }

    [Header("Action")]
    [SerializeField] bool walking;
    [SerializeField] bool usingTool;

    void Update()
    {
        if (!TimerCS.istPausiert)
        {
            walking = isWalking();
        }
    }

    private void FixedUpdate()
    {
        if (!TimerCS.istPausiert)
        {
            useTool();
            if (!usingTool)
            {
                selectTool();
                movePlayer();
            }
        }
    }

    // ------------------------------------------
    // ------------------------------------------

    [Header("PlayerMovement")]
    [SerializeField] float playerSpeed;

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

        transform.Translate(movement * playerSpeed * Time.deltaTime);
    }

    private bool isWalking()
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

    // ------------------------------------------

    [SerializeField] char direction1;
    public static char direction;

    bool isMovingUp;
    bool isMovingDown;
    bool isMovingLeft;
    bool isMovingRight;

    bool prevIsMovingUp;
    bool prevIsMovingDown;
    bool prevIsMovingLeft;
    bool prevIsMovingRight;

    public void directionDetection()
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
            if (!isWalking())
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
            if (!isWalking())
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
            if (!isWalking())
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
            if (!isWalking())
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

    // ------------------------------------------
    // ------------------------------------------

    [Header("Tools")]
    [SerializeField] static string toolInUse;

    private void useTool()
    {
        if (Input.GetMouseButton(0))
        {
            usingTool = true;
            // tool functionality
            if (toolInUse == "Axe")
            {

            }
            if (toolInUse == "Hoe")
            {

            }
            if (toolInUse == "WateringCan")
            {

            }
        }
        else
        {
            usingTool = false;
        }
    }


    private void selectTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toolInUse = "Axe";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            toolInUse = "Hoe";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            toolInUse = "WateringCan";
        }
    }






















    /*

       

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
    */
}
