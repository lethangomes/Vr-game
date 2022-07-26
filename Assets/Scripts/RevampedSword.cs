using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RevampedSword : MonoBehaviour
{
    public GameObject tip;
    public GameObject marker;
    public GameObject cylinder;
    public GameObject projectile;
    public GameObject bladeParent;
    public float targetV = 1;
    public float maxBeamLength = 3;
    public float coolDownLength = 0.1f;

    List<GameObject> blades = new List<GameObject>();
    List<Vector3> swingPos = new List<Vector3>();
    List<Quaternion> swingAngles = new List<Quaternion>();
    float currentBeamLength = 0;
    Vector3 lastPos;
    Quaternion lastRot;
    bool madeBeamLastFrame = false;
    bool active = false;
    public bool coolingDown = false;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = tip.transform.position;
        lastRot = tip.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float distTraveled = Vector3.Distance(lastPos, tip.transform.position);


        //Debug.Log(distTraveled / Time.deltaTime);

        if (((!madeBeamLastFrame && distTraveled/ (Time.deltaTime / Time.timeScale) > targetV) || (madeBeamLastFrame && distTraveled / (Time.deltaTime / Time.timeScale) > (targetV/2)))
            && currentBeamLength < maxBeamLength
            && active 
            && !coolingDown)
        {
            //Creates blade gameobject
            GameObject markerClone = Instantiate(marker, lastPos, Quaternion.identity);
            Vector3 midpoint = new Vector3((lastPos.x + tip.transform.position.x) / 2, (lastPos.y + tip.transform.position.y) / 2, (lastPos.z + tip.transform.position.z) / 2);
            GameObject cylinderClone = Instantiate(cylinder, midpoint, Quaternion.identity);

            //add tip position to list
            swingPos.Add(lastPos);

            //Angles blade
            cylinderClone.transform.LookAt(markerClone.transform);
            cylinderClone.transform.localScale = new Vector3(0.01f, 0.01f, distTraveled / 2);

            if(madeBeamLastFrame
                && (findDifference(cylinderClone.transform.rotation.eulerAngles.x, blades[blades.Count - 1].transform.rotation.eulerAngles.x) > 45
                || findDifference(cylinderClone.transform.rotation.eulerAngles.y, blades[blades.Count - 1].transform.rotation.eulerAngles.y) > 45
                || findDifference(cylinderClone.transform.rotation.eulerAngles.z, blades[blades.Count - 1].transform.rotation.eulerAngles.z) > 45))
            {
                
                coolingDown = true;
                Destroy(cylinderClone);
            }
            else
            {
                

                //Adds blades, and coresponding angles to list
                blades.Add(cylinderClone);
                swingAngles.Add(lastRot);
            }

            
            

            madeBeamLastFrame = true;
            currentBeamLength += distTraveled;
        }
        else if (!active)
        {
            if (blades.Count > 0)
            {
                blades.ForEach(Destroy);
            }
            blades = new List<GameObject>();
            swingAngles = new List<Quaternion>();
            swingPos = new List<Vector3>();
            madeBeamLastFrame = false;
            currentBeamLength = 0;
        }
        else if(madeBeamLastFrame)
        {

            GameObject parent = Instantiate(bladeParent);
            GameObject projectileClone;
            for (int i = 0; i < blades.Count; i++)
            {
                //Makes all blades children of one gameObject
                projectileClone = Instantiate(projectile, swingPos[i], Quaternion.identity);
                projectileClone.transform.rotation = swingAngles[i];
                blades[i].transform.SetParent(projectileClone.transform);
                projectileClone.transform.SetParent(parent.transform);

                blades[i].AddComponent<blade>();
            }
            //creates last projectile at end of swing
            projectileClone = Instantiate(projectile, tip.transform.position, Quaternion.identity);
            projectileClone.transform.rotation = tip.transform.rotation;
            projectileClone.transform.SetParent(parent.transform);

            /*
            parent.GetComponent<Lighsaber>().setTip(blades[0].transform.GetChild(1).gameObject);
            parent.GetComponent<Lighsaber>().setBase(blades[blades.Count-1].transform.GetChild(2).gameObject);
            */
            Destroy(parent, 10);

            blades = new List<GameObject>();
            swingAngles = new List<Quaternion>();
            swingPos = new List<Vector3>();
            madeBeamLastFrame = false;
            currentBeamLength = 0;

            if(!coolingDown && active)
            {
                coolingDown = true;
            }
            

        }
        
        if(coolingDown)
        {
            timer += Time.deltaTime / Time.timeScale;
            if(timer >= coolDownLength)
            {
                timer = 0;
                coolingDown = false;
            }
        }

        lastPos = tip.transform.position;
        lastRot = tip.transform.rotation;
    }

    public float findDifference(float x, float y)
    {
        return Math.Abs(x - y);
    }

    public void setActive(bool newActive)
    {
        active = newActive;
    }
}
