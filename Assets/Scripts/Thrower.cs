using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    public GameObject[] Objects;
    public float spawnRadius = 1;
    public float spawnCoolDown = 1;
    public float throwForce = 100;

    float timer = 0;
    List<GameObject> activeThrownObjects = new List<GameObject>();
    List<float> thrownObjectTimers = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnCoolDown)
        {
            int index = Random.Range(0, Objects.Length);
            GameObject thrownObject = Instantiate(Objects[index], transform.position + (Random.insideUnitSphere * spawnRadius), Quaternion.identity);
            transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
            thrownObject.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 1000 * thrownObject.GetComponent<Rigidbody>().mass);
            thrownObject.GetComponent<Rigidbody>().useGravity = false;

            //disables all colliders on gameobject
            Collider[] colliders = thrownObject.GetComponentsInChildren<Collider>();
            for (int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i] != null)
                {
                    colliders[i].enabled = false;
                }
            }

            activeThrownObjects.Add(thrownObject);
            thrownObjectTimers.Add(0);
            timer = 0;
        }

        
        for(int i = activeThrownObjects.Count - 1; i >= 0; i--)
        {
            if(thrownObjectTimers[i] > 3)
            {
                if(activeThrownObjects[i] != null)
                {
                    Rigidbody rb = activeThrownObjects[i].GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * throwForce * rb.mass);
                    rb.useGravity = true;
                    Destroy(activeThrownObjects[i], 20);

                    //enables all colliders on gameobject
                    Collider[] colliders = activeThrownObjects[i].GetComponentsInChildren<Collider>();
                    for (int j = 0; j < colliders.Length; j++)
                    {
                        if (colliders[j] != null)
                        {
                            colliders[j].enabled = true;
                        }
                    }
                }
                
                activeThrownObjects.RemoveAt(i);
                thrownObjectTimers.RemoveAt(i);
            }
            else
            {
                thrownObjectTimers[i] += Time.deltaTime;
            }
            
        }
        
        timer += Time.deltaTime;
    }
}
