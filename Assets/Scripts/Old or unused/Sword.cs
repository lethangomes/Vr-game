using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{
    public GameObject tip;
    public GameObject marker;
    public GameObject marker2;
    public GameObject beam;
    public GameObject AACone;
    GameObject playerCamera;

    public Collider bladeCollider;
    public Sheathe sheathe;

    private Vector3 lastPos;
    private Vector3 initialPos;
    private Vector3 initialRotation;
    
    public float targetV = 5;
    public float targetSwingV = 10;
    public float targetD = 0.75f;
    List<Vector3> positionsDuringSwing = new List<Vector3>();
    List<Quaternion> anglesDuringSwing = new List<Quaternion>();


    float timer = 0;
    bool swinging = false;

    // Start is called before the first frame update
    void Start()
    {
        lastPos = tip.transform.position;
        initialPos = tip.transform.position;
        initialRotation = tip.transform.rotation.eulerAngles;
        playerCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime / Time.timeScale;

        
        float x = tip.transform.position.x;
        float y = tip.transform.position.y;
        float z = tip.transform.position.z;

        //checks if the sword has stopped swinging or isnt active
        if ((Vector3.Distance(lastPos, tip.transform.position) / (Time.deltaTime / Time.timeScale)) < targetSwingV || !swinging)
        {//not moving fast
            float dist = Vector3.Distance(initialPos, tip.transform.position);
            float v = dist/timer;
            if(v > 5 && dist > targetD)
            {
                Debug.Log("Success");
                //creates 2 markers at the ends of the swing
                GameObject endMarker = Instantiate(marker, initialPos, Quaternion.identity);
                Instantiate(marker, tip.transform.position, Quaternion.identity);

                //creates marker at midpoint and angles it 
                Vector3 midpoint = new Vector3((initialPos.x + x)/2, (initialPos.y+y)/2, (initialPos.z+z)/2);
                GameObject midMarker = Instantiate(marker2, midpoint, Quaternion.identity);
                midMarker.transform.rotation = getAngleMidSwing(positionsDuringSwing, midpoint);

                //creates aim assist cone
                GameObject cone = Instantiate(AACone, midpoint, Quaternion.identity);
                cone.transform.rotation = getAngleMidSwing(positionsDuringSwing, midpoint);

                //cone.transform.Rotate(new Vector3(0, 0, 180));
                midMarker.transform.Rotate(new Vector3(90, 0, 0));

                //sets projectile to cone parent
                cone.transform.SetParent(midMarker.transform);

                //creates projectile hitbox and makes it child of midpoint marker
                GameObject projectile = Instantiate(beam, midpoint, Quaternion.identity);
                projectile.transform.LookAt(endMarker.transform);
                projectile.transform.GetChild(0).localScale = new Vector3(0.1f, (dist*2)/3, 0.1f);

                projectile.transform.SetParent(midMarker.transform);

                //ends timeslow if time has been slowed
                //sheathe.bladeBeamFired();

            }
            initialPos = tip.transform.position;
            initialRotation = tip.transform.rotation.eulerAngles;
            timer = 0;
            positionsDuringSwing = new List<Vector3>();
            anglesDuringSwing = new List<Quaternion>();
        }
        else
        {//moving fast
            positionsDuringSwing.Add(tip.transform.position);
            anglesDuringSwing.Add(tip.transform.rotation);
            //Debug.Log(tip.transform.position.x + "," + tip.transform.position.y + "," + tip.transform.position.z);
        }

        /*
        lastDX = dX;
        lastDY = dY;
        lastDZ = dZ;
        */
        lastPos = tip.transform.position;
       
    }

    float getDifference(float num1, float num2)
    {
        return Math.Abs(num1 - num2);
    }

    Quaternion getAngleMidSwing(List<Vector3> angles, Vector3 midpoint)
    {
        int closestIndex = 0;
        float closestDist = Vector3.Distance(angles[0], midpoint);

        for(int i = 0; i < angles.Count; i++)
        {
            float newDist = Vector3.Distance(angles[i], midpoint);
            //Debug.Log("closestDist: " + closestDist);
            
            //Debug.Log(angles);
            if (closestDist > newDist)
            {
                closestIndex = i;
                closestDist = newDist;
                //Debug.Log("closestDist: " + closestDist);
            }
        }

        
        return anglesDuringSwing[closestIndex];
    }

    //activates or deactivates sword beam mode
    public void changeState(bool active)
    {
        swinging = active;
    }

    //enables or disables the collider of the sword blade
    public void disableSwordCollider(bool active)
    {
        bladeCollider.enabled = active;
    }

}
