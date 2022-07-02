using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{
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
