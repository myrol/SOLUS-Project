using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaktorMeltdown : MonoBehaviour
{
    public GameObject light1, light2, light3, light4, light5, light6, seekers, screen1, screen2, reactor_screen1, reactor_screen2, reactor_screen3, reactor_but_interact, reactor_outer_color, reactor_inner_color;
    public AudioClip announcer, melting, flink;
    private bool done = false;
    float originalIntensity;
    Color32 originalColor;
    public Material but_Material_on;
    public Material but_Material_off;

    private void Start()
    {
        reactor_screen1.SetActive(false);
        reactor_screen2.SetActive(false);
        reactor_screen3.SetActive(false);
        reactor_but_interact.layer = 0;
        reactor_outer_color.GetComponent<MeshRenderer>().material = but_Material_off;
        reactor_inner_color.GetComponent<MeshRenderer>().material = but_Material_off;
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
        DialogueManager.Instance.AddToQueue(announcer);
        yield return new WaitForSeconds(3.3f);
        screen1.SetActive(false);
        screen2.SetActive(false);
        StartCoroutine(meltdownLight(light1));
        StartCoroutine(meltdownLight(light2));
        StartCoroutine(meltdownLight(light3));
        StartCoroutine(meltdownLight(light4));
        StartCoroutine(meltdownLight(light5));
        StartCoroutine(meltdownLight(light5));
        SoundManager.Instance.playSFX(flink);
        yield return new WaitForSeconds(.2f);
        SoundManager.Instance.playSFX(flink);
        yield return new WaitForSeconds(.3f);
        SoundManager.Instance.playSFX(melting);
        yield return new WaitForSeconds(2.5f);
        while (light1.GetComponent<Light>().intensity > 0)
        {
            light1.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light2.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light3.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light4.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light5.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            light6.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        reactor_screen1.SetActive(true);
        reactor_screen2.SetActive(true);
        reactor_screen3.SetActive(true);
        reactor_but_interact.layer = 7;
        reactor_outer_color.GetComponent<MeshRenderer>().material = but_Material_on;
        reactor_inner_color.GetComponent<MeshRenderer>().material = but_Material_on;
        seekers.SetActive(true);
        light1.GetComponent<Light>().color = originalColor;
        light2.GetComponent<Light>().color = originalColor;
        light3.GetComponent<Light>().color = originalColor;
        light4.GetComponent<Light>().color = originalColor;
        light5.GetComponent<Light>().color = originalColor;
        light6.GetComponent<Light>().color = originalColor;
        while (light1.GetComponent<Light>().intensity < originalIntensity)
        {
            light1.GetComponent<Light>().intensity += Time.deltaTime * 25;
            light2.GetComponent<Light>().intensity += Time.deltaTime * 25;
            light3.GetComponent<Light>().intensity += Time.deltaTime * 25;
            light4.GetComponent<Light>().color = originalColor;
            light5.GetComponent<Light>().color = originalColor;
            light6.GetComponent<Light>().color = originalColor;
            yield return null;
        }
    }

    public IEnumerator meltdownLight(GameObject lightObject)
    {
        while (lightObject.GetComponent<Light>().intensity > 0)
        {
            lightObject.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        lightObject.GetComponent<Light>().intensity = originalIntensity;
        while (lightObject.GetComponent<Light>().intensity > 0)
        {
            lightObject.GetComponent<Light>().intensity -= Time.deltaTime * 50;
            yield return null;
        }
        lightObject.GetComponent<Light>().color = new Color32(234, 93, 93, 255);
        while (lightObject.GetComponent<Light>().intensity < originalIntensity)
        {
            lightObject.GetComponent<Light>().intensity += Time.deltaTime * 5;
            yield return null;
        }
        yield return null;
    }
}
