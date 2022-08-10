using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
    Text text;
    GameController gameController;


    // Start is called before the first frame update
    void Start()
    {
        //gets text component and gameController
        text = gameObject.GetComponent<Text>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();
    }

    // Update is called once per frame
    void Update()
    {
        //displays score
        text.text = "Score: " + gameController.getScore();
    }
}
