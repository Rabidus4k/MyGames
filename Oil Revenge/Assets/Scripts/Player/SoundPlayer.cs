using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public AudioClip walkSound;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.playOnAwake = true;
        source.mute = false;
        source.loop = true;
    }

    public void PlaySound()
    {
        source.PlayOneShot(walkSound);

    }


}


