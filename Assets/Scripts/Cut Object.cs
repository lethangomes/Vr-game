using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutObject : MonoBehaviour
{

    float shrinkSpeed = 0.5f;
    float timer = 0;

    Vector3 initialScale;

    void Awake()
    {
        gameObject.tag = "Cut";
    }

    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 20)
        {
            transform.localScale -= new Vector3(initialScale.x * shrinkSpeed * Time.deltaTime, initialScale.y * shrinkSpeed * Time.deltaTime, initialScale.z * shrinkSpeed * Time.deltaTime);
        }
        if (transform.localScale.y < 0) 
        {
            Destroy(gameObject);
        }
        
    }
}
