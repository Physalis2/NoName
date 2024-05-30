using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class TimerCS : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public float startTime;
    public static float elapsedTime;

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

    public void resume()
    {
        Time.timeScale = 1.0f;
        istPausiert = false;
        pauseMenu.SetActive(false);
    }

    public void pause ()
    {
        Time.timeScale = 0f;
        istPausiert = true;
        pauseMenu.SetActive(true);
    }


    //Option Menu Buttons

    public void oppptionButton()
    {
        SceneManager.LoadScene("opptions");
    }
    public void mainMenuBotton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}
