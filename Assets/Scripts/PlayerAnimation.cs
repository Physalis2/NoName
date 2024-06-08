using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

public class PlayerAnimation : MonoBehaviour
{
    // Animation ============
    [Header("Animation Basics")]
    private static Animator animator;
    private static string currentClip;
    private PlayerToolSelectionAndUse playerTools;

    [Header("Boolean")]
    public char direction;
    public bool isMoving;
    public bool usingTool;

    [Header("AnimationMovement")]
    // Movement
    public static string IdleFront = "IdleFront";
    public static string IdleBack = "IdleBack";
    public static string IdleLeft = "IdleLeft";
    public static string IdleRigth = "IdleRigth";

    public static string WalkFront = "WalkFront";
    public static string WalkBack = "WalkBack";
    public static string WalkLeft = "WalkLeft";
    public static string WalkRigth = "WalkRigth";

    public static string RunFront = "RunFront";
    public static string RunBack = "RunBack";
    public static string RunLeft = "RunLeft";
    public static string RunRigth = "RunRigth";

    [Header("AnimationTools")]
    // Tools
    public static string TilingBack = "TillingBack";
    public static string TilingFront = "TillingFront";
    public static string TilingLeft = "TillingLeft";
    public static string TilingRigth = "TillingRigth";

    public static string AxeFront = "AxeFront";
    public static string AxeBack = "AxeBack";
    public static string AxeLeft = "AxeLeft";
    public static string AxeRigth = "AxeRigth";

    public static string WateringFront = "WateringFront";
    public static string WateringBack = "WateringBack";
    public static string WateringLeft = "WateringLeft";
    public static string WateringRigth = "WateringRigth";

    //  =====================

    private void Start()
    {
        direction = 'S';
        animator = GetComponent<Animator>();
        setUpPlayerMovement();
        setUpTools();
        
    }

    public static void ChangeAnimation(string newAnimation)
    {
        if (!TimerCS.istPausiert)
        {
            if (currentClip == newAnimation)
            {
                return;
            }
            else
            {
                animator.Play(newAnimation);

                currentClip = newAnimation;
            }
        }
    }

    private void Update()
    {
        isMoving = iswalking();
    }

    private void FixedUpdate()
    {
        if(!TimerCS.istPausiert)
        {
            if (playerTools.usingTool)
            {
                animateTool(playerTools.currentUsedTool);
            }
            else
            {
                animateMovement();
            }
        }
    }


    [Header("Animtion Movement")]

    bool isMovingUp;
    bool isMovingDown;
    bool isMovingLeft;
    bool isMovingRight;

    bool prevIsMovingUp;
    bool prevIsMovingDown;
    bool prevIsMovingLeft;
    bool prevIsMovingRight;

    private void setUpPlayerMovement()
    {
        direction = 'S';
        prevIsMovingUp = isMovingUp;
        prevIsMovingDown = isMovingDown;
        prevIsMovingLeft = isMovingLeft;
        prevIsMovingRight = isMovingRight;
    }



    public void animateMovement()
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
        if (playerTools.usingTool)
        {
            return false;
        }
        else
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
    }

    private void checkForBoolChangeToTrue()
    {
        if (!prevIsMovingUp && isMovingUp)
        {
            ChangeAnimation(WalkBack);
            direction = 'W';
        }
        if (!prevIsMovingDown && isMovingDown)
        {
            ChangeAnimation(WalkFront);
            direction = 'S';
        }
        if (!prevIsMovingLeft && isMovingLeft)
        {
            ChangeAnimation(WalkLeft);
            direction = 'A';
        }
        if (!prevIsMovingRight && isMovingRight)
        {
            ChangeAnimation(WalkRigth);
            direction = 'D';
        }
    }

    private void checkForBoolChangeToFalse()
    {
        if (prevIsMovingUp && !isMovingUp)
        {
            if (!iswalking())
            {
                ChangeAnimation(IdleBack);
                direction = 'W';
            }

            if (isMovingDown)
            {
                ChangeAnimation(WalkFront);
                direction = 'S';
            }
            if (isMovingLeft)
            {
                ChangeAnimation(WalkLeft);
                direction = 'A';
            }
            if (isMovingRight)
            {
                ChangeAnimation(WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingDown && !isMovingDown)
        {
            if (!iswalking())
            {
                ChangeAnimation(IdleFront);
                direction = 'S';
            }

            if (isMovingUp)
            {
                ChangeAnimation(WalkBack);
                direction = 'W';
            }
            if (isMovingLeft)
            {
                ChangeAnimation(WalkLeft);
                direction = 'A';
            }
            if (isMovingRight)
            {
                ChangeAnimation(WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingLeft && !isMovingLeft)
        {
            if (!iswalking())
            {
                ChangeAnimation(IdleLeft);
                direction = 'A';
            }

            if (isMovingUp)
            {
                ChangeAnimation(WalkBack);
                direction = 'W';
            }
            if (isMovingDown)
            {
                ChangeAnimation(WalkFront);
                direction = 'S';
            }
            if (isMovingRight)
            {
                ChangeAnimation(WalkRigth);
                direction = 'D';
            }
        }
        if (prevIsMovingRight && !isMovingRight)
        {
            if (!iswalking())
            {
                ChangeAnimation(IdleRigth);
            }

            if (isMovingUp)
            {
                ChangeAnimation(WalkBack);
                direction = 'W';
            }
            if (isMovingDown)
            {
                ChangeAnimation(WalkFront);
                direction = 'S';
            }
            if (isMovingLeft)
            {
                ChangeAnimation(WalkLeft);
                direction = 'A';
            }
        }
    }

    public void idleAnimation()
    {
        if (direction == 'W')
        {
            ChangeAnimation(IdleBack);
        }
        if (direction == 'S')
        {
            ChangeAnimation(IdleFront);
        }
        if (direction == 'A')
        {
            ChangeAnimation(IdleLeft);
        }
        if (direction == 'D')
        {
            ChangeAnimation(IdleRigth);
        }
    }

    [Header("Tools")]
    public string currentTool;
    public bool axe;
    public bool hoe;
    public bool watringCan;

    private void setUpTools()
    {
        playerTools = GetComponent<PlayerToolSelectionAndUse>();
    }

    private void animateTool(string tool)
    {
        currentTool = tool;
        if (tool == null)
        {
            Debug.Log("No toll used");
            idleAnimation();
            return;
        }
        if (direction == 'W')
        {
            if (tool == "axe")
            {
                ChangeAnimation(AxeBack);
            }
            if (tool == "hoe")
            {
                ChangeAnimation(TilingBack);
            }
            if (tool == "wateringcan")
            {
                ChangeAnimation(WateringBack);
            }
        }
        if (direction == 'S')
        {
            if (tool == "axe")
            {
                ChangeAnimation(AxeFront);
            }
            if (tool == "hoe")
            {
                ChangeAnimation(TilingFront);
            }
            if (tool == "wateringcan")
            {
                ChangeAnimation(WateringFront);
            }
        }
        if (direction == 'A')
        {
            if (tool == "axe")
            {
                ChangeAnimation(AxeLeft);
            }
            if (tool == "hoe")
            {
                ChangeAnimation(TilingLeft);
            }
            if (tool == "wateringcan")
            {
                ChangeAnimation(WateringLeft);
            }
        }
        if (direction == 'D')
        {
            if (tool == "axe")
            {
                ChangeAnimation(AxeRigth);
            }
            if (tool == "hoe")
            {
                ChangeAnimation(TilingRigth);
            }
            if (tool == "wateringcan")
            {
                ChangeAnimation(WateringRigth);
            }
        }
    }
}
