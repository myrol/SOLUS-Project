using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrify : MonoBehaviour
{
    public GameObject electric_arc, seekers, steampunk_keycard;
    public AudioClip dialogueClip;

    private void Start()
    {
        electric_arc.SetActive(false);
    }

    public IEnumerator Explode()
    {
        steampunk_keycard.layer = 8;
        electric_arc.SetActive(true);

        //play Sound
        gameObject.GetComponent<AudioSource>().Play();
        steampunk_keycard.transform.position = new Vector3(steampunk_keycard.transform.position.x, steampunk_keycard.transform.position.y, steampunk_keycard.transform.position.z + 0.1f);
        yield return new WaitForSeconds(2.25f);

        electric_arc.SetActive(false);
        GameObject.Find("DialogueManager").GetComponent<AudioSource>().PlayOneShot(dialogueClip);
        steampunk_keycard.layer = 7;

        yield return new WaitForSeconds(4);

        //play announcer, licht anmachen
        seekers.SetActive(false);

        yield return null;
    }
}