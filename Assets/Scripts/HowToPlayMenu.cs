using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayMenu : MonoBehaviour
{
    public bool inHTP;
    public GameObject hTPObject;
    public Button startButton, prevButton, nextButton;

    public List<Sprite> hTPSprites = new List<Sprite>();
    public int currentPos, maxPos;
    public Image currentImage;

    void Start()
    {
        
    }

    void Update()
    {
        if (hTPObject.activeInHierarchy)
        {
            currentImage.sprite = hTPSprites[currentPos];
        }

        if (currentPos == maxPos)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        if (currentPos == 0)
        {
            prevButton.interactable = false;
        }
        else
        {
            prevButton.interactable = true;
        }
    }

    public void NextImageInControls()
    {
        if (currentPos < maxPos)
        {
            currentPos++;
        }
    }

    public void PrevImageInControls()
    {
        if (currentPos > 0)
        {
            currentPos--;
        }
    }
}
