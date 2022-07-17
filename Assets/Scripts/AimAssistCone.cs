using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAssistCone : MonoBehaviour
{
    Transform projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = transform.root;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Cut" || col.tag == "Cuttable" || col.tag == "Explosive")
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {//was going to hit target anyways
                
            }
            else
            {
                //unattaches blade from projectile so blade doesn't rotate
                Transform child = transform.root.Find("Blade Beam(Clone)");
                child.parent = null;

                //stores inital blade angle
                Quaternion initialAngle = projectile.rotation;

                //points projectile at object within cone
                projectile.LookAt(col.gameObject.transform);
                projectile.Rotate(0, 180, 0);
                Quaternion newRotation = Quaternion.Slerp(initialAngle, projectile.rotation, 0.75f);
                //newRotation.eulerAngles = new Vector3((initialAngle.x + projectile.rotation.eulerAngles.x) / 2, (initialAngle.y + projectile.rotation.eulerAngles.y) / 2, (initialAngle.z + projectile.rotation.eulerAngles.z) / 2);
                projectile.rotation = newRotation;

                //resets projetile trajectory
                projectile.gameObject.GetComponent<bladeBeam>().timeAltered(Time.timeScale);

                //reattaches blade to projectile
                child.SetParent(projectile);
                
            }
            Destroy(gameObject);

        }
    }
}
