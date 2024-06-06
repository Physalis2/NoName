using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToolSelectionAndUse : MonoBehaviour
{
    [Header("")]
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] TileCurserCS tileCurser;


    [Header("")]
    public bool usingTool;
    public bool prevUsingTool;
    public bool axe;
    public bool hoe;
    public bool watringCan;

    void Start()
    {
        hoe = true;
    }

    void Update()
    {
        if (!TimerCS.istPausiert)
        {
            selectTool();
            usingTool = Input.GetMouseButton(0);

            checkforTool();

            prevUsingTool = usingTool;
        }
    }

    private void selectTool()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            axe = true; hoe = false; watringCan = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            axe = false; hoe = true; watringCan = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            axe = false; hoe = false; watringCan = true;
        }
    }

    private void checkforTool()
    {
        if (usingTool)
        {
            animatePlayer();
        }
        if (!usingTool)
        {
            playerMovement.idleAnimation();
        }
    }

    private void useTool()
    {
        
    }

    private void animatePlayer()
    {
        if (playerMovement.direction == 'W')
        {
            if (axe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.AxeBack);
            }
            if (hoe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.TilingBack);
            }
            if (watringCan)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WateringBack);
            }
        }
        if (playerMovement.direction == 'S')
        {
            if (axe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.AxeFront);
            }
            if (hoe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.TilingFront);
            }
            if (watringCan)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WateringFront);
            }
        }
        if (playerMovement.direction == 'A')
        {
            if (axe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.AxeLeft);
            }
            if (hoe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.TilingLeft);
            }
            if (watringCan)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WateringLeft);
            }
        }
        if (playerMovement.direction == 'D')
        {
            if (axe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.AxeRigth);
            }
            if (hoe)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.TilingRigth);
            }
            if (watringCan)
            {
                PlayerAnimation.ChangeAnimation(PlayerAnimation.WateringRigth);
            }
        }
    }
}
