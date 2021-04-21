using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawberryBush : Plant
{
    public GameObject[] bushVariations;

    private void Awake()
    {
        int rand = Random.Range(0, bushVariations.Length);
        transform.GetChild(rand).gameObject.SetActive(true);
    }

    public override void DoAbility()
    {

    }
}
