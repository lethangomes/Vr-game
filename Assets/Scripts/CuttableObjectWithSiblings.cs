using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObjectWithSiblings : MonoBehaviour
{
    //this script is for cuttable objects that are all under one parent. This makes it so when one is cut all the other objects will be able to move independently
    void OnDestroy()
    {
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            if(transform.parent.GetChild(i) != gameObject)
            {
                //adds rigidbody to all siblings
                transform.parent.GetChild(i).gameObject.AddComponent<Rigidbody>();
            }
        }
    }
}
