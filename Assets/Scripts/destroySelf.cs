using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroySelf : MonoBehaviour
{
    float timer = 0;
    public float lifeSpan = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
