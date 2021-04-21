using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelect()
    {

    }

    public void LoadLevel1()
    {

    }
    public void LoadLevel2()
    {

    }
    public void LoadLevel3()
    {

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
