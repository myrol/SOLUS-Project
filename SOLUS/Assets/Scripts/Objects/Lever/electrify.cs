using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrify : MonoBehaviour
{
    public GameObject electric_arc, seekers, steampunk_locker;
    public AudioClip dialogueClip;

    private void Start()
    {
        electric_arc.SetActive(false);
    }

    public IEnumerator Explode()
    {
        electric_arc.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
        steampunk_locker.GetComponent<Door>().open();
        yield return new WaitForSeconds(2.25f);

        electric_arc.SetActive(false);
        GameObject.Find("DialogueManager").GetComponent<AudioSource>().PlayOneShot(dialogueClip);
        yield return new WaitForSeconds(4);

        //play announcer, licht anmachen
        seekers.SetActive(false);

        yield return null;
    }
}