using System.Collections;
using UnityEngine;

public class SpinValveMain : MonoBehaviour
{

    public AudioClip turnAudio;
    public AudioClip water_smallAudio;
    public AudioSource source;
    public GameObject player;

    public void turnMain()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(turnerMain());
    }

    public IEnumerator turnerMain()
    {
        if (transform.localEulerAngles.y == 0 && player.GetComponent<StoryHolder>().getSteampunk() == 0)
        {
            float elapsed = 0.0f;
            source.PlayOneShot(turnAudio, 1f);

            yield return new WaitForSeconds(.25f);
            while (elapsed < 180f)
            {
                transform.Rotate(0.0f, -1f, 0.0f, Space.Self);
                elapsed += 0.12f;
                yield return null;
                if (elapsed > 60f && player.GetComponent<StoryHolder>().getSteampunk() == 0)
                {
                    player.GetComponent<StoryHolder>().addSteampunk();
                    StartCoroutine(waterSound());
                }
            }
        }
    }
    public IEnumerator waterSound()
    {
        //play wasser1
        source.PlayOneShot(water_smallAudio, 1f);
        yield return new WaitForSeconds(1.5f);

        //fade in wasser2
        AudioSource audioSource = GameObject.Find("Water_Player").GetComponent<AudioSource>();
        AudioSource audioSource2 = GameObject.Find("Water_Player_2").GetComponent<AudioSource>();
        audioSource.Play();
        float currentTime = 0;
        float start = 0;
        while (currentTime < 2f)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, 0.2f, currentTime / 2f);
            yield return null;
        }
        audioSource2.Play();
        yield return null;
    }
}