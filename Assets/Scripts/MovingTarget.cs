using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    /*
     * Script for a moving target
     */

    public float range;
    public int direction = 1;
    public float speed;

    int moveDirection = 1;
    public float amountMoved = 0;

    // Start is called before the first frame update
    void Start()
    {
        //randomly picks a distance and direction for the target to move
        range = Random.Range(1, 5);
        direction = (int)Random.Range(1, 6);
        speed = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //checks which direction it should be moving and moves that way
        switch (direction)
        {
            case 1:
                transform.position = transform.position + new Vector3(0, speed * Time.deltaTime * moveDirection, 0);
                break;
            case 2:
                transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime * moveDirection, 0);
                break;
            case 3:
                transform.position = transform.position + new Vector3(speed * Time.deltaTime * moveDirection, 0, 0);
                break;
            case 4:
                transform.position = transform.position + new Vector3(-speed * Time.deltaTime * moveDirection, 0, 0);
                break;
            case 5:
                transform.position = transform.position + new Vector3(0, 0, speed * Time.deltaTime * moveDirection);
                break;
            case 6:
                transform.position = transform.position + new Vector3(0, 0, -speed * Time.deltaTime * moveDirection);
                break;
        }

        //if object has moved more than the given range it changes direction
        amountMoved += speed * Time.deltaTime;
        if(amountMoved > range)
        {
            moveDirection *= -1;
            amountMoved = 0;
        }
    }
}
