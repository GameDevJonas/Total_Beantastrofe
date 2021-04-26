using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlovePointer : MonoBehaviour
{
    public GameObject openGlove, closedGlove;
    public bool isHolding;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePos.x, mousePos.y, 10);

        if (Input.GetMouseButton(0) || isHolding)
        {
            openGlove.SetActive(false);
            closedGlove.SetActive(true);
        }
        else if (!isHolding)
        {
            openGlove.SetActive(true);
            closedGlove.SetActive(false);
        }
    }
}
