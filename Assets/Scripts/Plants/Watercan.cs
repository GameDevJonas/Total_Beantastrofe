using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watercan : Indicator
{
    public override void PressMouse()
    {
        Debug.Log("Tap");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        Debug.Log("Hit: ", hit.collider.gameObject);
        if (hit.collider != null && hit.collider.CompareTag("Tile"))
        {
            TileInfo info = hit.collider.gameObject.GetComponent<TileInfo>();
            if (info.planted)
            {
                foreach(Plant child in info.GetComponentsInChildren<Plant>())
                {
                    if(!child.GetComponent<StrawberryBush>()) CheckForPlant(child);
                }
            }
        }
    }


    public void CheckForPlant(Plant plant)
    {
        if(plant.myStage == Plant.PlantStage.first)
        {
            plant.OnWater();
            GameObject.Find("UpgradeAudio").GetComponent<AudioSource>().Play();
            myButton.inCooldown = true;
            FindObjectOfType<GlovePointer>().isHolding = false;
            currency.RemoveCurrency(plant.GetComponent<Plant>().cost);
            Destroy(this.gameObject);
        }
    }
}
