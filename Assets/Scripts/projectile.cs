using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    /*
     * This is code for the "points" on the projectile the sword fires. They are the points connected by the blades, and they are what actually causes the projectile to move
     */


    Rigidbody rb;
    public float speed = 50;
    public float aimAssistPower = 1;
    GameController gameController;
    public float lastTimeScale = 1;
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //gets game controller and rigidbody
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * -speed);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if timeScale has changed since the last frame
        
        if(Time.timeScale != lastTimeScale)
        {
            //lowers velocity if time has slowed
            timeAltered(Time.timeScale);
            lastTimeScale = Time.timeScale;
        }

    }

    //this is from when I was experimenting with aim assist,
    /*
    public GameObject FindClosestObject()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("target");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            if (Vector3.Distance(go.transform.position, position) < distance)
            {
                closest = go;
                distance = Vector3.Distance(go.transform.position, position); ;
            }
        }
        return closest;
    }
    */

    //when timeScale is changed, changes velocity accordingly
    public void timeAltered(float factor)
    {
        rb.velocity *= 0;
        rb.AddForce(transform.forward * -speed * factor);
    }
}
