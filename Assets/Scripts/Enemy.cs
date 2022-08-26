using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    const int DEFAULT = 0;
    const int SPAWNING_THROWERS = 1;
    const int BIG_ATTACK = 2;

    public GameObject thrower;
    public GameObject thrower2;

    int state = DEFAULT;
    List<GameObject> activeThrowers = new List<GameObject>();
    float timer = 0;
    float phaseTimer = 0;
    float stateLength = 5;
    int round = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case DEFAULT:
                //picks random length for the next state
                stateLength = Random.Range(20, 30);
                state = SPAWNING_THROWERS;
                break;
            case SPAWNING_THROWERS:
                //spawns 3 throwers plus the round count each phase
                if((phaseTimer > (stateLength/(3 + round)) || timer == 0) && timer < stateLength)
                {
                    activeThrowers.Add(Instantiate(thrower));
                    activeThrowers[activeThrowers.Count - 1].GetComponent<Thrower>().setDirection(Random.Range(0,1) < 0.5);
                    phaseTimer = 0;
                }

                //once the timer is up all throwers are destroyed and the next phase starts
                if(timer > stateLength)
                {
                    reset();
                }

                phaseTimer += Time.deltaTime;
                timer += Time.deltaTime;
                break;
            case BIG_ATTACK:

                if(phaseTimer > 1 && timer < 5)
                {
                    /*
                    Vector2 randomPoint = Random.insideUnitCircle * 5;
                    activeThrowers.Add(Instantiate(thrower2, new Vector3(randomPoint.x, randomPoint.y + 10, 20), Quaternion.identity));
                    */
                    spawnLineOfThrowers(8);
                    phaseTimer = 0;
                }

                if(timer > 15)
                {
                    reset();
                    round++;
                }

                phaseTimer += Time.deltaTime;
                timer += Time.deltaTime;
                break;
        }
    }

    void destroyAllThrowers()
    {
        for (int i = 0; i < activeThrowers.Count; i++)
        {
            activeThrowers[i].GetComponent<Thrower>().selfDestruct();
        }
    }

    void reset()
    {
        destroyAllThrowers();
        activeThrowers = new List<GameObject>();
        state = BIG_ATTACK;
        timer = 0;
        phaseTimer = 0;
    }

    void spawnLineOfThrowers(int num)
    {
        Vector2 endPoint = Random.insideUnitCircle.normalized * 5;
        float x = endPoint.x;
        float y = endPoint.y;

        for(int i = 0; i < num; i++)
        {
            Vector3 spawnPoint = new Vector3(x - ((x / (num / 2)) * i), y - ((y / (num / 2)) * i) + 10, 20);
            activeThrowers.Add(Instantiate(thrower2, spawnPoint, Quaternion.identity));
        }
    }
}
