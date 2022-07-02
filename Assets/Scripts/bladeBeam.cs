using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bladeBeam : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 50;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * -speed);
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (-speed)  * Time.deltaTime;
    }
}
