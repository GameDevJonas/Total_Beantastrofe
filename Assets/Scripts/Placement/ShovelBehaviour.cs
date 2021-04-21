using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PressMouse();
        }
    }

    void PressMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null && hit.collider.CompareTag("Plant"))
        {
            TileInfo info = hit.collider.gameObject.GetComponentInParent<TileInfo>();
            info.planted = false;
            info.GetComponent<BoxCollider2D>().enabled = true;
            Destroy(hit.collider.gameObject);
        }
    }
}
