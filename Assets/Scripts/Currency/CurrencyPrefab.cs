using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CurrencyPrefab : MonoBehaviour
{
    CurrencySystem system;
    float timer;

    private void Awake()
    {
        system = FindObjectOfType<CurrencySystem>();
        timer = system.prefabTime;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(timer <= 0)
        //{
        //    Destroy(this.gameObject);
        //}
        //else
        //{
        //    timer -= Time.deltaTime;
        //}
    }

    private void OnMouseDown()
    {
        GameObject.Find("BeanStonksAudio").GetComponent<AudioSource>().Play();
        system.AddCurrency(system.generateAmount);
        Destroy(this.gameObject);
    }
}
