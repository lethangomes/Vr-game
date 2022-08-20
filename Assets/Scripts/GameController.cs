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

        //https://freesound.org/people/Leszek_Szary/sounds/133279/
        audioClips.Add("Warp", Resources.Load<AudioClip>("Audio/133279__leszek-szary__game-teleport"));

        //https://freesound.org/people/qubodup/sounds/60013/
        audioClips.Add("Whoosh", Resources.Load<AudioClip>("Audio/60013__qubodup__whoosh"));

        //https://freesound.org/people/qubodup/sounds/60013/
        audioClips.Add("Clock Ticking", Resources.Load<AudioClip>("Audio/458627__tetrisrocker__clock"));
    }

    //plays given audio clip
    public void playAudio(string clipName, AudioSource source, float volume = 1)
    {
        source.PlayOneShot(audioClips[clipName], volume);
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
