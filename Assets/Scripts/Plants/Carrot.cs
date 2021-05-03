using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Plant
{
    public GameObject dirtPrefab;
    public Transform shootPoint;
    public float shootSpeed;
    public float shootIntervalAtUpgrade;
    public override void DoAbility()
    {
        GetComponentInChildren<Animator>().SetTrigger("Attack");
        GameObject clone = Instantiate(dirtPrefab, shootPoint.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 + shootSpeed, 0));
        clone.GetComponent<DamageEnemy>().damage = damage;
        Destroy(clone, 3);
        if(myStage == PlantStage.second)
        {
            Invoke("SecondShot", shootIntervalAtUpgrade);
        }
    }

    void SecondShot()
    {
        GameObject cloneTwo = Instantiate(dirtPrefab, shootPoint.position, Quaternion.identity);
        cloneTwo.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 + shootSpeed, 0));
        cloneTwo.GetComponent<DamageEnemy>().damage = damage;
        Destroy(cloneTwo, 3);
    }
}
