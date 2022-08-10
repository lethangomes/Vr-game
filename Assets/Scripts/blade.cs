using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    /*
     * This is the code for the individual "blades" in each projectile the sword fires
     */ 
    
    int index;
    Transform parent;
    Transform root;
    Transform parentNextSibling;

    // Start is called before the first frame update
    void Start()
    {
        //each blade is effectively connecting 2 points that are constantly moving outward, these lines get the 2 points this blade needs to connect
        index = transform.parent.GetSiblingIndex();
        root = transform.root;
        parent = transform.parent;
        parentNextSibling = root.GetChild(index + 1);
    }

    // Update is called once per frame
    void Update()
    {
        //gets the midpoint of the 2 points the blade connects
        Vector3 midpoint = new Vector3((parent.position.x + parentNextSibling.position.x) / 2, (parent.position.y + parentNextSibling.position.y) / 2, (parent.position.z + parentNextSibling.position.z) / 2);

        //sets position to midpoint, angles blade correctly, and scales blade to connect the 2 points
        transform.position = midpoint;
        transform.localScale = new Vector3(0.01f, 0.01f, Vector3.Distance(parent.position, parentNextSibling.position) / 2);
        transform.LookAt(parent);
    }
}
