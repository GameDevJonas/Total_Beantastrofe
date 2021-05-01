using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlantButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject placementIndicator;

    public Plant plant;
    public Image myCooldownImage;

    private TextMeshProUGUI costText;
    private bool canBuy;
    public bool inCooldown;
    private float cooldownTimer;
    private CurrencySystem currency;

    // Start is called before the first frame update
    void Start()
    {
        currency = FindObjectOfType<CurrencySystem>();
        costText = GetComponentInChildren<TextMeshProUGUI>();
        costText.text = "" + plant.cost;
        cooldownTimer = plant.cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currency.currencyAmount < plant.cost)
        {
            costText.color = currency.expensive;
            canBuy = false;
        }
        else
        {
            costText.color = currency.normal;
            canBuy = true;
        }
        if (inCooldown)
        {
            InCooldown();
        }
        GetComponent<Image>().raycastTarget = !inCooldown;
    }

    public void InCooldown()
    {
        if (cooldownTimer <= 0)
        {
            inCooldown = false;
            cooldownTimer = plant.cooldownTime;

        }
        else
        {
            myCooldownImage.fillAmount = cooldownTimer / plant.cooldownTime;
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0) && canBuy && !inCooldown)
        {
            ActivateShovel shovel = FindObjectOfType<ActivateShovel>();
            if (shovel.shovelActive)
            {
                shovel.shovelActive = false;

                shovel.shovel.SetActive(shovel.shovelActive);
                shovel.glove.SetActive(!shovel.shovelActive);
                return;
            }
            FindObjectOfType<GlovePointer>().isHolding = true;
            GameObject g = Instantiate(placementIndicator, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
            g.GetComponent<Indicator>().myButton = this;
        }
        //g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, 0);
    }
}
