using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatwaveRayAlign : MonoBehaviour
{
    public List<Transform> rays = new List<Transform>();
    public float childScale;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform.GetComponentInChildren<Transform>())
        {
            rays.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //childScale = GetComponent<RadialLayout>().fDistance * 2.8f;
        //transform.localScale = new Vector3(childScale, childScale, 1);
        foreach (Transform child in rays)
        {
            Vector3 vectorToTarget = transform.position - child.transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            angle -= 90;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            child.transform.rotation = Quaternion.Slerp(child.transform.rotation, q, Time.deltaTime * speed);
            child.localScale = new Vector3(childScale, childScale, 1);
        }
    }
}
