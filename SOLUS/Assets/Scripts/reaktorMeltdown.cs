using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reaktorMeltdown : MonoBehaviour
{
    public GameObject light1, light2, light3, light4, seekers;
    public AudioClip melting, flink;

    public void startMeltdownRrountine()
    {
        StartCoroutine(meltdown());
    }

    public IEnumerator meltdown()
    {
        Color32 originalColor = light1.GetComponent<Light>().color;
        int elapsed = 0;
        DialogueManager.Instance.AddToQueue(flink);
        while (elapsed < 255)
        {
            elapsed++;
            light1.GetComponent<Light>().color = new Color32(170, 201, 238, (byte)(255-elapsed));
            yield return null;
        }
        elapsed = 0;
        DialogueManager.Instance.AddToQueue(flink);
        light1.GetComponent<Light>().color = new Color32(170, 201, 238, 255);
        while (elapsed < 255)
        {
            elapsed++;
            light1.GetComponent<Light>().color = new Color32(170, 201, 238, (byte)(255 - elapsed));
            yield return null;
        }
        elapsed = 0;
        light1.GetComponent<Light>().color = new Color32(234, 93, 93, 0);
        DialogueManager.Instance.AddToQueue(melting);
        while (elapsed < 255)
        {
            elapsed++;
            light1.GetComponent<Light>().color = new Color32(234, 93, 93, (byte)(elapsed));
            yield return null;
        }
        elapsed = 0;
        yield return null;
    }
}
