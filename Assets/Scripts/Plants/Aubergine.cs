using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aubergine : Plant
{
    public GameObject smashPrefab;
    public float upgradedAbilityTimer;
    public override void DoAbility()
    {
        if(myStage == PlantStage.second)
        {
            abilityTimerSet = upgradedAbilityTimer;
        }
        GameObject clone = Instantiate(smashPrefab, transform.position, Quaternion.identity);
        clone.GetComponent<DamageEnemy>().damage = damage;
        Destroy(clone, .2f);
    }
}
