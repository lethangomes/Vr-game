using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevampedSword : MonoBehaviour
{
    public GameObject tip;
    public GameObject marker;
    public GameObject cylinder;
    public GameObject projectile;
    public float targetV = 1;

    Vector3 lastPos;
    bool madeBeamLastFrame = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = tip.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distTraveled = Vector3.Distance(lastPos, tip.transform.position);
        //Debug.Log(distTraveled / Time.deltaTime);

        if ((!madeBeamLastFrame && distTraveled/ Time.deltaTime > targetV) || (madeBeamLastFrame && distTraveled / Time.deltaTime > (targetV/2)))
        {
            GameObject markerClone = Instantiate(marker, lastPos, Quaternion.identity);
            Vector3 midpoint = new Vector3((lastPos.x + tip.transform.position.x) / 2, (lastPos.y + tip.transform.position.y) / 2, (lastPos.z + tip.transform.position.z) / 2);
            GameObject cylinderClone = Instantiate(cylinder, midpoint, Quaternion.identity);
            cylinderClone.transform.LookAt(markerClone.transform);
            cylinderClone.transform.localScale = new Vector3(0.01f, 0.01f, distTraveled / 2);

            GameObject projectileClone = Instantiate(projectile, midpoint, Quaternion.identity);
            projectileClone.transform.rotation = tip.transform.rotation;
            cylinderClone.transform.SetParent(projectileClone.transform);

            madeBeamLastFrame = true;
        }
        else
        {
            madeBeamLastFrame = false;
        }

        lastPos = tip.transform.position;
    }
}
