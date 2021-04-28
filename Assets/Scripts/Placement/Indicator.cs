using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Indicator : MonoBehaviour
{
    public GameObject plant;

    private CurrencySystem currency;

    // Start is called before the first frame update
    void Start()
    {
        currency = FindObjectOfType<CurrencySystem>();
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
        if (Input.GetMouseButtonDown(1))
        {
            RemovePlant();
        }
    }

    public void PressMouse()
    {
        Debug.Log("Tap");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        Debug.Log("Hit: ", hit.collider.gameObject);
        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            TileInfo info = hit.collider.gameObject.GetComponent<TileInfo>();
            if (!info.planted && info.fertility >= .9f)
            {
                GameObject plantClone = Instantiate(plant, info.transform);
                plantClone.transform.localPosition = new Vector3(0, 0, 0);
                info.planted = true;
                FindObjectOfType<GlovePointer>().isHolding = false;
                currency.RemoveCurrency(plant.GetComponent<Plant>().cost);
                Destroy(this.gameObject);
            }
        }
    }

    public void RemovePlant()
    {
        FindObjectOfType<GlovePointer>().isHolding = false;
        Destroy(this.gameObject);
    }
}
