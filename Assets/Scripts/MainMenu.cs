using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        
    }


    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void OptionsMenu()
    {

    }

    public void BackBtn()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
