using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnPlayButton2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OnPlayButton3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }




}
