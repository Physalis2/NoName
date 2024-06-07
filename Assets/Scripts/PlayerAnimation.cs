using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimation : MonoBehaviour
{
    // Animation ============
    [Header("Animation Basics")]
    private static Animator animator;
    private static string currentClip;

    [Header("Boolean")]
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
        animator = GetComponent<Animator>();
        SetUpPlayerMovement();
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

    public static IEnumerator playOnce(string newAnimation)
    {
        string oldClip = currentClip;

        ChangeAnimation(newAnimation);

        yield return new WaitForSeconds(1.3f);

        ChangeAnimation(oldClip);
    }

    private void Update()
    {
        isMoving = iswalking();
    }

    private void FixedUpdate()
    {
        if(!TimerCS.istPausiert)
        {
            animateMovement();
        }
    }


    [Header("Animtion Movement")]

    char direction;

    bool isMovingUp;
    bool isMovingDown;
    bool isMovingLeft;
    bool isMovingRight;

    bool prevIsMovingUp;
    bool prevIsMovingDown;
    bool prevIsMovingLeft;
    bool prevIsMovingRight;

    private void SetUpPlayerMovement()
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
            if (!isMoving)
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

}
