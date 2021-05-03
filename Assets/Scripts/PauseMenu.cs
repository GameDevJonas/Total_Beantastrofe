using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused, inHTP;

    public GameObject pauseAnim, hTPObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseUnPause()
    {
        isPaused = !isPaused;
        switch (isPaused)
        {
            case true:
                pauseAnim.SetActive(true);
                Time.timeScale = 0;
                break;
            case false:
                Time.timeScale = 1;
                pauseAnim.SetActive(false);
                hTPObj.SetActive(false);
                break;
        }
    }

    public void ReturnToMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HTP()
    {
        inHTP = !inHTP;
        hTPObj.SetActive(inHTP);
    }
}
