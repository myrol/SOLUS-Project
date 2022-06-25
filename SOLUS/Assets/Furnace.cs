using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Furnace : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private UnityEvent eve;
    [SerializeField] private string tag;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            if (player.GetComponent<StoryHolder>().steampunk_furnace == 0)
            {
                AudioSource audioSource = gameObject.GetComponent<AudioSource>();
                audioSource.Play();
                float currentTime = 0;
                while (currentTime < 2f)
                {
                    currentTime += Time.deltaTime;
                    audioSource.volume = Mathf.Lerp(0f, 0.628f, currentTime / 2f);
                }
            }
            other.gameObject.SetActive(false);
        }
    }

    public void loadFurnace()
    {
        if (player.GetComponent<StoryHolder>().steampunk_furnace == 1)
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.Play();
            float currentTime = 0;
            while (currentTime < 2f)
            {
                currentTime += Time.deltaTime;
                audioSource.volume = Mathf.Lerp(0f, 0.628f, currentTime / 2f);
            }
        }
    }
}
