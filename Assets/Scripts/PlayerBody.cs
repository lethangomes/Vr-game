using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBody : MonoBehaviour
{
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        //gets gameController
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Cuttable" || col.tag == "Explosive")
        {
            //Deducts points for getting hit by an uncut object
            gameController.addScore(-1000);
        }
    }
}
