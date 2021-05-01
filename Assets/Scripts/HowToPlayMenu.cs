using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HowToPlayMenu : MonoBehaviour
{
    public bool inHTP;
    public GameObject hTPObject;
    public Button prevButton, nextButton;

    public List<Sprite> hTPSprites = new List<Sprite>();
    public List<string> hTPText = new List<string>();
    public int currentPos, maxPos;
    public Image currentImage;
    public TextMeshProUGUI currentText;

    void Start()
    {
        
    }

    void Update()
    {
        if (hTPObject.activeInHierarchy)
        {
            currentImage.sprite = hTPSprites[currentPos];
            currentText.text = hTPText[currentPos];
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
