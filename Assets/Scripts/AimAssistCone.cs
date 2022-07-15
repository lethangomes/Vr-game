using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistCone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "target")
        {
            //unattaches blade from projectile so blade doesn't rotate
            Transform child = transform.root.Find("Blade Beam(Clone)");
            child.parent = null;

            //points projectile at object within cone
            transform.root.LookAt(col.gameObject.transform);
            transform.root.Rotate(0, 180, 0);

            //resets projetile trajectory
            transform.root.gameObject.GetComponent<bladeBeam>().timeAltered(Time.timeScale);

            //reattaches blade to projectile
            child.SetParent(transform.root);
            Destroy(gameObject);
        }
    }
}
