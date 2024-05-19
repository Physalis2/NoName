using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager ManagerScript;

    private void Awake()
    {
        ManagerScript = this;
    }
}
