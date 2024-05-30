using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUi : MonoBehaviour
{
    string game = "Level";
    string opptions = "opptions";

    public void startButton()
    { 
        SceneManager.LoadScene(game);
    }

    public void oppptionButton()
    {
        SceneManager.LoadScene(opptions);
    }

    public void quitButton()
    {
        Application.Quit();
        Debug.Log("quit");
    }

}
