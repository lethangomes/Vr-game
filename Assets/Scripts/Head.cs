using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code originally written by Justin P Barnett
 * https://www.youtube.com/watch?v=MYOjQICbd8I
 */



public class Head : MonoBehaviour

{

    [SerializeField] private Transform rootObject, followObject;

    [SerializeField] private Vector3 positionOffset, rotationOffset, headBodyOffset;



    private void LateUpdate()

    {

        rootObject.position = transform.position + headBodyOffset;

        rootObject.forward = Vector3.ProjectOnPlane(followObject.forward, Vector3.up).normalized;



        transform.position = followObject.TransformPoint(positionOffset);

        transform.rotation = followObject.rotation * Quaternion.Euler(rotationOffset);

    }

}
