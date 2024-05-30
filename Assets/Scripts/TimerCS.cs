using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCS : MonoBehaviour
{
    public float startTime;
    public float elapsedTime;

    public static bool istPausiert;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (istPausiert)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
        if (!istPausiert)
        {
            elapsedTime = Time.time - startTime;
        }
        else
        {
            
        }
    }

    public static void resume()
    {
        Time.timeScale = 1.0f;
        istPausiert = false;
    }

    public static void pause ()
    {
        Time.timeScale = 0f;
        istPausiert = true;
    }
}
