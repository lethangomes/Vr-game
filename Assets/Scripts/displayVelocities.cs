using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class displayVelocities : MonoBehaviour
{
    public GameObject Object;
    Text text;

    private Vector3 lastPos;
    private float lastDX = 0;
    private float lastDY = 0;
    private float lastDZ = 0;
    public float tolerance = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        lastPos = Object.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        float x = Object.transform.position.x;
        float y = Object.transform.position.y;
        float z = Object.transform.position.z;

        float dX = x - lastPos.x;
        float dY = y - lastPos.y;
        float dZ = z - lastPos.z;

        String output;
        if(getDifference(dX, lastDX) > tolerance || getDifference(dY, lastDY) > tolerance || getDifference(dZ, lastDZ) > tolerance)
        {
            output = "not Straight";
        }
        else
        {
            output = "straight";
        }


        text.text = "X: " + Math.Atan2(Object.transform.position.y,Object.transform.position.x)*(180/Math.PI) + "\nY: "
            + Object.transform.position.y + "\nZ: "
            + Math.Atan2(Object.transform.position.y, Object.transform.position.z) * (180 / Math.PI) + "\n" + output;

        lastDX = dX;
        lastDY = dY;
        lastDZ = dZ;*/

        text.text = (Vector3.Distance(lastPos, Object.transform.position) / Time.deltaTime) +"";

        lastPos = Object.transform.position;
        

        
    }

    float getDifference(float num1, float num2)
    {
        return Math.Abs(num1 - num2);
    }
}
