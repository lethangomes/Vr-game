using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CutObject : MonoBehaviour
{
    /*
     * This script is attached to objects after they have been cut. It basically just gets rid of them after a bit so the game doesn't lag
     */

    float shrinkSpeed = 0.5f;
    float timer = 0;

    Vector3 initialScale;

    void Awake()
    {
        //gives object the "Cut" tag
        gameObject.tag = "Cut";
    }

    void Start()
    {
        //gets the initial scale of the object
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //Waits for 20 seconds divided by the number of times this object has been cut, and then shrinks the object before eventually destroying it
        if(timer > (20 / gameObject.name.Count(f => (f == '_'))))
        {
            transform.localScale -= new Vector3(initialScale.x * shrinkSpeed * Time.deltaTime, initialScale.y * shrinkSpeed * Time.deltaTime, initialScale.z * shrinkSpeed * Time.deltaTime);
        }
        if (transform.localScale.y < 0) 
        {
            Destroy(gameObject);
        }
        
    }
}
