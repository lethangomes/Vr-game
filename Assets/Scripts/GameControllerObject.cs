using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerObject : MonoBehaviour
{
    GameController gameController;

    // Start is called before the first frame update
    //one line to get gameController:
    //gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();

    void Awake()
    {
        gameController = new GameController();
    }

    public GameController getGameController()
    {
        return gameController;
    }
}
