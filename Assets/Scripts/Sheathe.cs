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

    // Start is called before the first frame update
    void Start()
    {
        
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

    //slows time
    public void slowTime()
    {
        Time.timeScale = timeSlowAmount;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        timeSlowed = true;
    }

    //resumes time
    public void endTimeSlow()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
        timeSlowed = false;
    }

    //when a blade beam is fired, ends time slow and resets timer if time is slowed
    public void bladeBeamFired()
    {
        if (timeSlowed)
        {
            timer -= 4;
            if(timer < 0)
            {
                timer = 0;
            }
        }
    }
}
