using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioSource sfx, music;
    [SerializeField] private List<AudioClip> footsteps;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    public void playFootsteps()
    {
        sfx.PlayOneShot(footsteps[Random.Range(0, footsteps.Count)]);
    }

    public void playSFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void playMusic(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }
}
