using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField, Range(0,1)] private float sfx_volume = 1f;
    [SerializeField, Range(0,1)] private float music_volume = 1f;
    [SerializeField] private AudioSource sfx, music;

    // Player movement
    public List<AudioClip> player_footsteps;
    public List<AudioClip> player_liftOff;
    public List<AudioClip> player_jumping;

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

    private void Update()
    {
        sfx.volume = sfx_volume;
        music.volume = music_volume;
    }

    public void playRandom(List<AudioClip> list)
    {
        sfx.PlayOneShot( list[Random.Range(0, list.Count)] );
    }

    public void playSFX(AudioClip clip)
    {
        sfx.PlayOneShot(clip);
    }

    public void playSFX(AudioSource source)
    {
        source.volume = sfx_volume;
        source.PlayOneShot(source.clip);
    }

    public void playMusic(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }
}
