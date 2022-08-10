using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    float score = 0;

    //GameController class
    public GameController()
    {
        //add audio clips here

        //https://freesound.org/people/XfiXy8/sounds/467291/
        audioClips.Add("Unsheathe", Resources.Load<AudioClip>("Audio/467291__xfixy8__sword-unsheathed"));

        //https://freesound.org/people/Streety/sounds/30247/
        audioClips.Add("Cut", Resources.Load<AudioClip>("Audio/30247__streety__sword5"));
    }

    //plays given audio clip
    public void playAudio(string clipName, AudioSource source, float volume = 1)
    {
        source.PlayOneShot(audioClips[clipName]);
    }

    public void addScore(float amount)
    {
        score += amount;
    }

    public float getScore()
    {
        return score;
    }
}
