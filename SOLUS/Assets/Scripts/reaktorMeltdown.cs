using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaktorMeltdown : MonoBehaviour
{
    public GameObject light1, light2, light3, light4, seekers, screen1, screen2, reactor_screen1, reactor_screen2, reactor_screen3, reactor_screen4;
    public AudioClip melting, flink;
    private bool done = false;
    float originalIntensity;
    Color32 originalColor;

    private void Start()
    {
        reactor_screen1.SetActive(false);
        reactor_screen2.SetActive(false);
        reactor_screen3.SetActive(false);
        reactor_screen4.SetActive(false);
    }

    public void startMeltdownRrountine()
    {
        originalColor = light1.GetComponent<Light>().color;
        originalIntensity = light1.GetComponent<Light>().intensity;
        if (!done)
            StartCoroutine(meltdown());
        done = true;
    }

    public IEnumerator meltdown()
    {
        screen1.SetActive(false);
        screen2.SetActive(false);
        StartCoroutine(meltdownLight(light1));
        StartCoroutine(meltdownLight(light2));
        StartCoroutine(meltdownLight(light3));
        StartCoroutine(meltdownLight(light4));
        yield return new WaitForSeconds(3);
        while (light1.GetComponent<Light>().intensity > 0)
        {
            light1.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light2.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light3.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light4.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        reactor_screen1.SetActive(true);
        reactor_screen2.SetActive(true);
        reactor_screen3.SetActive(true);
        reactor_screen4.SetActive(true);
        seekers.SetActive(true);
        light1.GetComponent<Light>().color = originalColor;
        light2.GetComponent<Light>().color = originalColor;
        light3.GetComponent<Light>().color = originalColor;
        light4.GetComponent<Light>().color = originalColor;
        while (light1.GetComponent<Light>().intensity < originalIntensity)
        {
            light1.GetComponent<Light>().intensity += Time.deltaTime * 50;
            light2.GetComponent<Light>().intensity += Time.deltaTime * 50;
            light3.GetComponent<Light>().intensity += Time.deltaTime * 50;
            light4.GetComponent<Light>().intensity += Time.deltaTime * 50;
            yield return null;
        }
    }

    public IEnumerator meltdownLight(GameObject lightObject)
    {
        AudioSource source = gameObject.GetComponent<AudioSource>();
        source.PlayOneShot(flink);
        while (lightObject.GetComponent<Light>().intensity > 0)
        {
            lightObject.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        source.PlayOneShot(flink);
        lightObject.GetComponent<Light>().intensity = originalIntensity;
        while (lightObject.GetComponent<Light>().intensity > 0)
        {
            lightObject.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        lightObject.GetComponent<Light>().color = new Color32(234, 93, 93, 255);
        source.PlayOneShot(melting);
        while (lightObject.GetComponent<Light>().intensity < originalIntensity)
        {
            lightObject.GetComponent<Light>().intensity += Time.deltaTime * 5;
            yield return null;
        }
        yield return null;
    }
}
