using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
    /*
     * This is the script for an empty gameobject that is a child of the player head. It just follows the head around and copies the y rotation.
     * This object makes it possible to me to have a sheathe attached to the "body" of the player
     */

    public GameObject MainCamera;
    Quaternion targetAngle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //copies position and y rotation of main camera
        gameObject.transform.position = MainCamera.transform.position;
        targetAngle.eulerAngles = new Vector3(0, MainCamera.transform.rotation.eulerAngles.y, 0);
        gameObject.transform.rotation = targetAngle;

    }
}
