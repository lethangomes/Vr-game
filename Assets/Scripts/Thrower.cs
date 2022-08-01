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
            Debug.Log(index);
            GameObject thrownObject = Instantiate(Objects[index], transform.position + (Random.insideUnitSphere * spawnRadius), Quaternion.identity);
            transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
            thrownObject.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 1000);
            thrownObject.GetComponent<Rigidbody>().useGravity = false;
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
                    activeThrownObjects[i].GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
                }
                activeThrownObjects[i].GetComponent<Rigidbody>().useGravity = true;
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
