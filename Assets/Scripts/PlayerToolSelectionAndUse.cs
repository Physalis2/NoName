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

    public string currentUsedTool;

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
        if (!prevUsingTool && usingTool)
        {
            if (axe) currentUsedTool = "axe";
            if (hoe) currentUsedTool = "hoe";
            if (watringCan) currentUsedTool = "wateringcan";
        }
        if (prevUsingTool && !usingTool)
        {
            currentUsedTool = null;
        }
    }
}
