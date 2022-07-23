using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    Vector3 referencePoint;
    GameObject tip;
    float bladeLength;
    float referenceDistance;

    // Start is called before the first frame update
    void Start()
    {
        tip = transform.GetChild(1).gameObject;
        referencePoint = GameObject.FindWithTag("Sword Reference Point").transform.position;
        bladeLength = transform.localScale.z;
        referenceDistance = Vector3.Distance(referencePoint, tip.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localScale = new Vector3(0.1f, 0.1f, (bladeLength * Vector3.Distance(referencePoint, tip.transform.position) / referenceDistance));
    }
}
