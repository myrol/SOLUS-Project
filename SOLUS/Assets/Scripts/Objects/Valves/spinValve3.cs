using System.Collections;
using UnityEngine;

public class spinValve3 : MonoBehaviour
{

    public AudioClip turnAudio;
    public AudioSource source;
    public int ok = 0;
    private float direction;

    public void setOk()
    {
        ok = 1;
    }

    public void turn()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(turner());
    }

    public IEnumerator turner()
    {
        if (transform.localEulerAngles.y == 0)
        {
            float elapsed = 0.0f;
            direction = 1f;
            source.PlayOneShot(turnAudio, 1f);

            yield return new WaitForSeconds(.3f);
            int counter = 0;
            if (ok == 0)
            {
                while (elapsed < 30f)
                {
                    transform.Rotate(0.0f, 1f * direction, 0.0f, Space.Self);
                    elapsed += 0.12f;
                    counter++;
                    if (counter > 0 && counter == 125)
                    {
                        direction = -1f;
                    }
                    yield return null;
                }
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                yield return new WaitForSeconds(0.45f);
                source.Stop();
            }
            else
            {
                while (elapsed < 180f)
                {
                    transform.Rotate(0.0f, 1f, 0.0f, Space.Self);
                    elapsed += 0.12f;
                    counter++;
                    if (counter == 750)
                    {
                        StartCoroutine(silence());
                    }
                    yield return null;
                }
            }
        }
    }
    public IEnumerator silence()
    {
        AudioSource audioSource = GameObject.Find("Water_Player_2").GetComponent<AudioSource>();
        AudioSource audioSource2 = GameObject.Find("Steam_Player").GetComponent<AudioSource>();
        GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().addProgress();
        AudioSource audioSource3 = GameObject.Find("turbine").GetComponent<AudioSource>();
        audioSource.Play();
        audioSource2.Play();
        audioSource3.Play();
        float currentTime = 0;
        while (currentTime < 2f)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0.2f, 0f, currentTime / 2f);
            audioSource3.volume = Mathf.Lerp(0f, 0.6f, currentTime / 2f);
            yield return null;
        }
        audioSource.Stop();
        yield return new WaitForSeconds(2);
        yield return null;
    }
}