using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheathe : MonoBehaviour
{
    public float timeSlowAmount = 0.2f;
    bool timeSlowed = false;
    public float maxSlowTime = 2;
    float timer = 0;
    public GameObject slider;
    public float rechargeRate = 2;
    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerObject>().getGameController();
    }

    // Update is called once per frame
    void Update()
    {
        //subracts from or adds to time slow timer depending on if time has slowed or not
        if(timeSlowed && timer > 0 && Time.deltaTime / Time.timeScale < 1)
        {
            timer -= Time.deltaTime / Time.timeScale;
            //Debug.Log(Time.deltaTime / Time.timeScale);
        }
        else if(!timeSlowed && timer < maxSlowTime)
        {
            timer += Time.deltaTime * rechargeRate;
        }

        //if time runs out the time slow effect will end
        if(timeSlowed && timer <= 0)
        {
            endTimeSlow();
        }

        //updates slider
        slider.transform.localScale = new Vector3(slider.transform.localScale.x, slider.transform.localScale.y, timer/maxSlowTime);
    }

    public void unsheathe()
    {
        gameController.playAudio("Unsheathe", GetComponent<AudioSource>());
    }

    //slows time
    public void slowTime()
    {
        Time.timeScale = timeSlowAmount;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        timeSlowed = true;
        gameController.playAudio("Clock Ticking", GetComponent<AudioSource>());

        adjustPitchToTimeScale();
    }

    //resumes time
    public void endTimeSlow()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        timeSlowed = false;
        GetComponent<AudioSource>().Stop();

        adjustPitchToTimeScale();
    }

    public void adjustPitchToTimeScale()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        int scalar = 1;
        if (Time.timeScale < 1)
        {
            scalar = 10;
        }
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i].pitch = Time.timeScale * scalar;
        }
    }

    //increases time that time is slowed
    public void addTime(float amount)
    {
        if (timeSlowed && timer < maxSlowTime)
        {
            timer += amount;
            
        }
    }
}
