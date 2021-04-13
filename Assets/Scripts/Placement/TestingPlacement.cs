using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestingPlacement : MonoBehaviour, IPointerDownHandler
{
    public GameObject placeMentIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject g = Instantiate(placeMentIndicator, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        //g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, 0);
    }
}
