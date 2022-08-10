using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    public GameObject rotor;
    public GameObject tailRotor;
    public int maxV = 5;

    GameObject player;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("MainCamera");
        rb = transform.root.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //points towards player and flies at them
        transform.root.LookAt(player.transform);
        if(rb.velocity.magnitude < maxV)
        {
            rb.AddForce(transform.root.forward * 10);
        }
        
    }

    void OnDestroy()
    {
        //add rigidibody to rotors
        rotor.AddComponent<Rigidbody>();
        tailRotor.AddComponent<Rigidbody>();
        Debug.Log("This script is doing things despite being disabled");
    }
}