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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > spawnCoolDown)
        {
            GameObject thrownObject = Instantiate(Objects[Random.Range(0, Objects.Length - 1)], transform.position + (Random.insideUnitSphere * spawnRadius), Quaternion.identity);
            transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
            thrownObject.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);
            thrownObject.GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * Random.Range(100, 1000));
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
