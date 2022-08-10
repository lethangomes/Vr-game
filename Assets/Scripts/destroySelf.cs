using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour
{
    /*
     * This script destroys an object after a set amount of time. Kind of redundant
     */
    public float lifeSpan = 10;

    // Start is called before the first frame update
    void Start()
    {
        //destroys self after a given amount of time
        Destroy(gameObject, lifeSpan);
    }
}
