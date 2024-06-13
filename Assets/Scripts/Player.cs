using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {

    }

    void Start()
    {

    }

    [Header("Action")]
    [SerializeField] bool walking;
    [SerializeField] bool usingTool1;

    void Update()
    {
        if (!TimerCS.istPausiert)
        {
            direction1 = direction;
            usingTool1 = usingTool;
            walking = isWalking;
        }
    }

    private void FixedUpdate()
    {
        if (!TimerCS.istPausiert)
        {
            useTool();
            // Aktionen die nicht whärend tools genutzt werden können
            if (!usingTool)
            {
                directionDetection();
                selectTool();
                movePlayer();
            }
        }
    }

    // ------------------------------------------
    // ------------------------------------------

    [Header("PlayerMovement")]
    [SerializeField] float playerSpeed;
    public static bool isWalking;

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        movement.Normalize();

        transform.Translate(movement * playerSpeed * Time.deltaTime);
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
            if (!isWalking)
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
            if (!isWalking)
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
            if (!isWalking)
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
            if (!isWalking)
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
    [SerializeField] static bool usingTool;

    private void useTool()
    {
        if (Input.GetMouseButton(0))
        {
            usingTool = true;
            isWalking = false;

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
}
