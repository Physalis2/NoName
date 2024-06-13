using System.Collections;
using System.Collections.Generic;
using Unity.Profiling.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.XR;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEditor.IMGUI.Controls.PrimitiveBoundsHandle;

class PlayerAnimation : MonoBehaviour
{
    // Animation ============
    [Header("Animation Basics")]
    private Animator animator;
    private PlayerMovement playerMovement;
    private string currentClip;
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

    public void ChangeAnimation(string newAnimation)
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

    }

    int toolusage = 0;

    private void FixedUpdate()
    {
        if (!TimerCS.istPausiert && 0 ==1)
        {
            if (playerTools.usingTool)
            {
                toolusage = 1;
                animateTool(playerTools.currentUsedTool);
            }
            else
            {
                if ((playerTools.currentUsedTool == "none") && (toolusage == 1))
                {
                    toolusage = 0;
                    playerTools.checkforTool();
                    currentTool = playerTools.currentUsedTool;
                    idleAnimation();
                }

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
        if (tool == "none")
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
