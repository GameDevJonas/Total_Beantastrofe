using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : Plant
{
    public GameObject dirtPrefab;
    public Transform shootPoint;
    public float shootSpeed;
    public override void DoAbility()
    {
        GameObject clone = Instantiate(dirtPrefab, shootPoint.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 + shootSpeed, 0));
        Destroy(clone, 3);
    }
}
