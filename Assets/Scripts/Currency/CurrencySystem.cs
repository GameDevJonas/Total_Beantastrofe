using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
    public int starterCurrency;

    public float generatingInterval;
    public int generateAmount;

    [HideInInspector] public int currencyAmount;
    public TextMeshProUGUI currencyText;

    public GameObject currencyPrefab;
    public float prefabTime;

    public Color normal, expensive;

    void Start()
    {
        currencyAmount = starterCurrency;
    }

    // Update is called once per frame
    void Update()
    {
        currencyText.text = "" + currencyAmount;
    }

    public void AddCurrency(int amount)
    {
        currencyAmount += amount;
    }

    public void RemoveCurrency(int amount)
    {
        currencyAmount -= amount;
    }
}
