using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    // Animation ============
    [Header("Animation")]

    private static Animator animator;
    private static AnimationClip currentClip;

    [Header("AnimationMovement")]
    // Movement
    [SerializeField] public static AnimationClip IdleFront;
    [SerializeField] public static AnimationClip IdleBack;
    [SerializeField] public static AnimationClip IdleLeft;
    [SerializeField] public static AnimationClip IdleRigth;
                     
    [SerializeField] public static AnimationClip WalkFront;
    [SerializeField] public static AnimationClip WalkBack;
    [SerializeField] public static AnimationClip WalkLeft;
    [SerializeField] public static AnimationClip WalkRigth;
                     
    [SerializeField] public static AnimationClip RunFront;
    [SerializeField] public static AnimationClip RunBack;
    [SerializeField] public static AnimationClip RunLeft;
    [SerializeField] public static AnimationClip RunRigth;

    [Header("AnimationTools")]
    // Tools
    [SerializeField] public static AnimationClip TilingFront;
    [SerializeField] public static AnimationClip TilingBack;
    [SerializeField] public static AnimationClip TilingLeft;
    [SerializeField] public static AnimationClip TilingRigth;
                     
    [SerializeField] public static AnimationClip AxeFront;
    [SerializeField] public static AnimationClip AxeBack;
    [SerializeField] public static AnimationClip AxeLeft;
    [SerializeField] public static AnimationClip AxeRigth;
                     
    [SerializeField] public static AnimationClip WateringFront;
    [SerializeField] public static AnimationClip WateringBack;
    [SerializeField] public static AnimationClip WateringLeft;
    [SerializeField] public static AnimationClip WateringRigth;

    //  =====================

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public static void ChangeAnimation(AnimationClip newAnimation)
    {
        if (currentClip == newAnimation) return;

        animator.Play(newAnimation.name);

        currentClip = newAnimation;
    }

    private void Update()
    {
        
    }
}
