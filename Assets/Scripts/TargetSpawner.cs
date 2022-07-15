using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject target;
    public GameObject movingTarget;
    public int numberOfTargets = 10;

    public float maxX, minX, maxY, minY, maxZ, minZ;

    public bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        if(active)
        { 
            spawnTargets(); 
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnTargets()
    {
        //creates 10 targets
        for (int i = 0; i < numberOfTargets; i++)
        {
            //creates random coords within range
            float randX = Random.Range(minX, maxX);//maxX - (rand.nextDouble() * (Math.Abs(maxX - minX)));
            float randY = Random.Range(minY, maxY);//maxY - (rand.nextDouble() * (Math.Abs(maxY - minY)));
            float randZ = Random.Range(minZ, maxZ);//maxZ - (rand.nextDouble() * (Math.Abs(maxZ - minZ)));

            //randomly makes the targets moving
            if (Random.Range(-10, 10) > 0)
            {
                Instantiate(target, new Vector3(randX, randY, randZ), Quaternion.identity);
            }
            else
            {
                Instantiate(movingTarget, new Vector3(randX, randY, randZ), Quaternion.identity);
            }

        }
    }

    public void setActive(bool newActive)
    {
        active = newActive;
    }
}
