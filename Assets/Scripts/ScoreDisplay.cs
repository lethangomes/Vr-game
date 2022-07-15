using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //pops up slightly when created and looks towards player;
        rb = GetComponent<Rigidbody>();
        rb.AddForce(0, Random.Range(300, 600), 0);

        transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
