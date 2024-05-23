using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    //Load Scene
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("The Player Has Quit The Game");
    }

    //Settings 

    public void Settings()
    {
        SceneManager.LoadScene(4);
    }
}
