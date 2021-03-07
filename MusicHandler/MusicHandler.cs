using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource Song1;
    public bool song1selected = true;
    public bool mute = false;
    public AudioSource deathsound;
    public AudioSource daypasssound;

    // Update is called once per frame
    void Update()
    {
        if(song1selected && !Song1.isPlaying && !mute)
        {
            deathsound.Stop();
            Song1.Play();
        }
        if (mute)
        {
            Song1.Stop();
        }
        if (!song1selected)
        {
            Song1.Stop();
        }
    }
    public void death()
    {
        if (!mute)
        {
            song1selected = false;
            deathsound.Play();
        }
        
    }
    public void daypass()
    {
        if (!mute)
            daypasssound.Play(); 
    }
    
}
