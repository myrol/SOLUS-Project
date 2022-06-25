using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Furnace : MonoBehaviour
{
    public GameObject player;
    public AudioClip planks;
    AudioSource audioSource;

    [SerializeField] private UnityEvent eve;

#pragma warning disable CS0108
    [SerializeField] private string tag;
#pragma warning restore CS0108

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            if (player.GetComponent<StoryHolder>().steampunk_furnace == 0)
            {
                audioSource.PlayOneShot(planks);
                player.GetComponent<StoryHolder>().steampunk_furnace++;
                other.gameObject.SetActive(false);
                eve.Invoke();
            }
        }
    }

    public void startFurnace()
    {
        if (player.GetComponent<StoryHolder>().steampunk_furnace == 1)
        {
            audioSource.Play();
            float currentTime = 0;
            while (currentTime < 2f)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0f, 0.628f, currentTime / 2f);
            }
            player.GetComponent<StoryHolder>().steampunk_furnace++;
        }
    }
}
