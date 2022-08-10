using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    /*
     * This is the script for the explosion that spawns after certain objects are cut
     */
    public float radius = 3;
    public float power = 50;
    public float delay = 1;
    public GameObject fx;
    float timer = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        //waits a small amount of time before applying force
        if(timer > delay && Time.timeScale == 1)
        {
            //gets all objects within a certain radius of explosion
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            //applies explosion force to all objects nearby
            foreach(Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.attachedRigidbody;
                if(rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius);
                }
                
            }

            //instantiates explosion effect, destroys self, and destroys the effects after its done
            GameObject fxClone = Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(fxClone, 3);
            Destroy(gameObject);
        }
        
    }
}
