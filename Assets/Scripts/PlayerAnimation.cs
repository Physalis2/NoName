using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Animation ============
    [Header("Animation")]

    private static Animator animator;
    private static string currentClip;

    [Header("AnimationMovement")]
    // Movement
    public static string IdleFront = "IdleFront";
    public static string IdleBack  = "IdleBack";
    public static string IdleLeft  = "IdleLeft";
    public static string IdleRigth = "IdleRigth";
    
    public static string WalkFront = "WalkFront";
    public static string WalkBack  = "WalkBack";
    public static string WalkLeft  = "WalkLeft";
    public static string WalkRigth = "WalkRigth";
    
    public static string RunFront = "RunFront";
    public static string RunBack  = "RunBack";
    public static string RunLeft  = "RunLeft";
    public static string RunRigth = "RunRigth";

    [Header("AnimationTools")]
    // Tools
    public static string TilingBack  = "TilingBack";
    public static string TilingFront = "TilingFront";
    public static string TilingLeft  = "TilingLeft";
    public static string TilingRigth = "TilingRigth";
    
    public static string AxeFront = "AxeFront";
    public static string AxeBack  = "AxeBack";
    public static string AxeLeft  = "AxeLeft";
    public static string AxeRigth = "AxeRigth";
    
    public static string WateringFront = "WateringFront";
    public static string WateringBack  = "WateringBack";
    public static string WateringLeft  = "WateringLeft";
    public static string WateringRigth = "WateringRigth";

    //  =====================

    public static bool isWaling;

    private void Start()
    {
        animator = GetComponent<Animator>();
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
        if (isWaling == false)
        {
            ChangeAnimation(IdleFront);
        }
        if (TimerCS.istPausiert)
        {
            animator.enabled = false;
        }
        else
        {
            animator.enabled = true;
        }
    }
}
