using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker_sound : MonoBehaviour
{
    public AudioClip floating;
    private AudioSource Audio;
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.clip = floating;
        Audio.loop = true;
        Audio.Play();
    }
}
