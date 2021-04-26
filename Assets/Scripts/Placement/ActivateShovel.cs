using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ActivateShovel : MonoBehaviour, IPointerDownHandler
{
    public GameObject shovel, glove;
    public bool shovelActive;
    // Start is called before the first frame update
    void Start()
    {
        shovelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && shovelActive)
        {
            shovelActive = !shovelActive;

            shovel.SetActive(shovelActive);
            glove.SetActive(!shovelActive);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        shovelActive = !shovelActive;

        shovel.SetActive(shovelActive);
        glove.SetActive(!shovelActive);
    }
}
