using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FollowMouse : MonoBehaviour, IPointerDownHandler
{
    public GameObject plant;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.Translate((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (Input.GetMouseButtonDown(0))
        {
            PressMouse();
        }
    }

    public void PressMouse()
    {
        Debug.Log("Tap");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            TileInfo info = hit.collider.gameObject.GetComponent<TileInfo>();
            if (!info.planted && info.fertility >= .9f)
            {
                Instantiate(plant, info.transform.position, Quaternion.identity);
                info.planted = true;
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
