using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevampedSword : MonoBehaviour
{
    public GameObject tip;
    public GameObject marker;
    public GameObject cylinder;
    public GameObject projectile;
    public GameObject bladeParent;
    public float targetV = 1;
    public float maxBeamLength = 3;

    List<GameObject> blades = new List<GameObject>();
    List<Quaternion> swingAngles = new List<Quaternion>();
    float currentBeamLength = 0;
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

        if ((!madeBeamLastFrame && distTraveled/ Time.deltaTime > targetV) || (madeBeamLastFrame && distTraveled / Time.deltaTime > (targetV/2)) && currentBeamLength < maxBeamLength)
        {
            //Creates blade gameobject
            GameObject markerClone = Instantiate(marker, lastPos, Quaternion.identity);
            Vector3 midpoint = new Vector3((lastPos.x + tip.transform.position.x) / 2, (lastPos.y + tip.transform.position.y) / 2, (lastPos.z + tip.transform.position.z) / 2);
            GameObject cylinderClone = Instantiate(cylinder, midpoint, Quaternion.identity);

            //Angles blade
            cylinderClone.transform.LookAt(markerClone.transform);
            cylinderClone.transform.localScale = new Vector3(0.01f, 0.01f, distTraveled / 2);

            //Adds blades, and coresponding angles to list
            blades.Add(cylinderClone);
            swingAngles.Add(tip.transform.rotation);
            

            madeBeamLastFrame = true;
            currentBeamLength += distTraveled;
        }
        else if(madeBeamLastFrame)
        {
            GameObject parent = Instantiate(bladeParent);
            for(int i = 0; i < blades.Count; i++)
            {
                //applies force to all blade beams
                GameObject projectileClone = Instantiate(projectile, blades[i].transform.position, Quaternion.identity);
                projectileClone.transform.rotation = swingAngles[swingAngles.Count/2];
                blades[i].transform.SetParent(projectileClone.transform);
                blades[i].AddComponent<blade>();
                projectileClone.transform.SetParent(parent.transform);
            }

            parent.GetComponent<Lighsaber>().setTip(blades[0].transform.GetChild(1).gameObject);
            parent.GetComponent<Lighsaber>().setBase(blades[blades.Count-1].transform.GetChild(2).gameObject);

            blades = new List<GameObject>();
            swingAngles = new List<Quaternion>();
            madeBeamLastFrame = false;
            currentBeamLength = 0;
        }

        lastPos = tip.transform.position;
    }
}
