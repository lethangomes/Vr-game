using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
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
        
        if(timer > delay)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach(Collider nearbyObject in colliders)
            {
                Rigidbody rb = nearbyObject.attachedRigidbody;
                if(rb != null)
                {
                    rb.AddExplosionForce(power, transform.position, radius);
                }
                
            }
            GameObject fxClone = Instantiate(fx, transform.position, Quaternion.identity);
            Destroy(fxClone, 3);
            Destroy(gameObject);
        }
        
    }
}
