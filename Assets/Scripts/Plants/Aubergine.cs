using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aubergine : Plant
{
    public GameObject smashPrefab;

    public override void DoAbility()
    {
        GameObject clone = Instantiate(smashPrefab, transform.position, Quaternion.identity);
        Destroy(clone, .2f);
    }
}
