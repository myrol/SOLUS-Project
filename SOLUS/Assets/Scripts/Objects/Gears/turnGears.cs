using System.Collections;
using UnityEngine;

public class turnGears : MonoBehaviour
{
    public GameObject gear11; // -> 32
    public GameObject gear2;  // -> 12
    public GameObject gear8;  // -> 28
    public GameObject gear1;  // -> 12
    public GameObject tesla;
    public GameObject sparks_2;
    public GameObject sparks_3;
    public GameObject machine_group;
    public GameObject turbine;

    public AudioClip explosionAudio;
    public AudioClip dropAudio;
    public AudioClip CutSceneAudio;

    public float speed;

    /*DEMO
     * private void Update()
    {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * (32f / 12f) * (28f / 12f), Space.Self);
    }*/

    private void Start()
    {
        sparks_2.SetActive(false);
        sparks_3.SetActive(false);
    }

    public IEnumerator turner()
    {
        AudioSource audioSource = turbine.GetComponent<AudioSource>();
        audioSource.volume = 1f;
        audioSource.PlayOneShot(CutSceneAudio, 1f);
        float elapsed = 0.0f;
        int counter = 0;
        while (elapsed < 5.0f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            counter += 1;
            if (counter > 20)
                StartCoroutine(machine_group.GetComponent<MovingSparks>().startMovement());
            if (elapsed < 2f)
            {
                if ((counter % 4) == 0)
                    sparks_2.SetActive(true);
                else if (((counter + 2) % 4) == 0)
                    sparks_2.SetActive(false);
            }
            else if(elapsed < 3.5f)
            {
                if ((counter % 8) == 0)
                    sparks_2.SetActive(true);
                else if (((counter + 4) % 6) == 0)
                    sparks_2.SetActive(false);
            }
            else
            {
                if ((counter % 8) == 0)
                {
                    sparks_2.SetActive(true);
                    sparks_3.SetActive(true);
                }
                else if (((counter + 4) % 12) == 0)
                {
                    sparks_2.SetActive(false);
                    sparks_3.SetActive(false);
                }
            }
            yield return null;
        }
        sparks_2.SetActive(true);
        sparks_3.SetActive(true);
        while (elapsed < 10.0f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 5.0f, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 5.0f * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 5.0f * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 5.0f * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(tesla.GetComponent<electrify>().Explode());
        yield return new WaitForSeconds(2);
        counter = 0;
        while (elapsed > 0f)
        {
            audioSource.volume -= 0.001f;
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed -= Time.deltaTime;
            counter -= 1;
            if (elapsed < 2f)
            {
                if ((counter % 4) == 0)
                {
                    sparks_3.SetActive(false);
                    sparks_2.SetActive(true);
                }
                else if (((counter + 2) % 4) == 0)
                    sparks_2.SetActive(false);
            }
            else if (elapsed < 3.5f)
            {
                if ((counter % 8) == 0)
                {
                    sparks_3.SetActive(false);
                    sparks_2.SetActive(true);
                }
                else if (((counter + 4) % 6) == 0)
                    sparks_2.SetActive(false);
            }
            else
            {
                if ((counter % 8) == 0)
                {
                    sparks_2.SetActive(true);
                    sparks_3.SetActive(true);
                }
                else if (((counter + 4) % 12) == 0)
                {
                    sparks_2.SetActive(false);
                    sparks_3.SetActive(false);
                }
            }
            yield return null;
        }
        StopCoroutine(machine_group.GetComponent<MovingSparks>().startMovement());
        sparks_2.SetActive(false);
        sparks_3.SetActive(false);
        audioSource.Stop();
        yield return null;
    }

    public IEnumerator Explode()
    {

        AudioSource audioSource = turbine.GetComponent<AudioSource>();
        audioSource.volume = 0.7f;
        audioSource.PlayOneShot(explosionAudio, 1f);
        float elapsed = 0.0f;
        int counter = 0;
        while (elapsed < 5f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            counter += 1;
            if (counter > 20)
                StartCoroutine(machine_group.GetComponent<MovingSparks>().startMovement());
            if (elapsed < 2f)
            {
                if ((counter % 4) == 0)
                    sparks_2.SetActive(true);
                else if (((counter + 2) % 4) == 0)
                    sparks_2.SetActive(false);
            }
            else if (elapsed < 3.5f)
            {
                if ((counter % 8) == 0)
                    sparks_2.SetActive(true);
                else if (((counter + 4) % 6) == 0)
                    sparks_2.SetActive(false);
            }
            else
            {
                if ((counter % 8) == 0)
                {
                    sparks_2.SetActive(true);
                    sparks_3.SetActive(true);
                }
                else if (((counter + 4) % 12) == 0)
                {
                    sparks_2.SetActive(false);
                    sparks_3.SetActive(false);
                }
            }
            yield return null;
        }
        sparks_2.SetActive(false);
        sparks_3.SetActive(false);
        gear11.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear8.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        //wegschleudern
        elapsed = 0.0f;
        while (elapsed < 0.5f)
        {
            gear11.transform.localPosition = gear11.transform.localPosition + new Vector3(0.1f, 0.05f, -0.02f);
            gear2.transform.localPosition = gear2.transform.localPosition + new Vector3(-0.1f, 0.05f, -0.01f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        audioSource = gear11.GetComponent<AudioSource>();
        audioSource.PlayOneShot(dropAudio, 1f);
        gear11.transform.localRotation = Quaternion.Euler(82.2f, 90f, 90f);
        gear11.transform.localPosition = new Vector3(71.641f, 5.233f, 34.754f);
        gear2.transform.localRotation = Quaternion.Euler(-45f, 45f, 0f);
        gear2.transform.localPosition = new Vector3(1.456f, 0.439f, 25.29f);
        yield return null;
    }
}