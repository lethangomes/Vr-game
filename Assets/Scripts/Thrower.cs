using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Thrower : MonoBehaviour
{
    public GameObject[] Objects;
    public float spawnRadius = 1;
    public float spawnCoolDown = 1;
    public float throwForce = 100;
    public int direction = 1;
    public float speed = 10;

    float timer = 0;
    Rigidbody rb;
    List<GameObject> activeThrownObjects = new List<GameObject>();
    List<float> thrownObjectTimers = new List<float>();
    List<Vector3> thrownObjectAngles = new List<Vector3>();
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving code
        transform.LookAt(player.transform);
        transform.position += transform.right * speed * direction * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, 10 + ((float)Math.Sin(Time.time) * 3), transform.position.z);



        //throwing code
        if(timer > spawnCoolDown)
        {
            int index = UnityEngine.Random.Range(0, Objects.Length);
            GameObject thrownObject = Instantiate(Objects[index], transform.position + (UnityEngine.Random.insideUnitSphere * spawnRadius), Quaternion.identity);
            thrownObject.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.insideUnitSphere * 1000 * thrownObject.GetComponent<Rigidbody>().mass);
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
            thrownObjectAngles.Add(transform.forward);
            timer = 0;
        }

        
        for(int i = activeThrownObjects.Count - 1; i >= 0; i--)
        {
            if(thrownObjectTimers[i] > 3)
            {
                if(activeThrownObjects[i] != null)
                {
                    Rigidbody rb = activeThrownObjects[i].GetComponent<Rigidbody>();
                    rb.AddForce(thrownObjectAngles[i] * throwForce * rb.mass);
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
                thrownObjectAngles.RemoveAt(i);
            }
            else
            {
                thrownObjectTimers[i] += Time.deltaTime;
            }
            
        }
        
        timer += Time.deltaTime;
    }
}
