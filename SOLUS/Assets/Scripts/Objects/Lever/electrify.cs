using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class electrify : MonoBehaviour
{
    public GameObject electric_arc, seekers;
    public AudioClip dialogueClip;
    [SerializeField] private UnityEvent eve;

    private void Start()
    {
        electric_arc.SetActive(false);
    }

    public IEnumerator Explode()
    {
        electric_arc.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
        eve.Invoke();
        yield return new WaitForSeconds(2.25f);

        electric_arc.SetActive(false);
        DialogueManager.Instance.AddToQueue(dialogueClip);
        yield return new WaitForSeconds(4);

        //play announcer, licht anmachen
        seekers.SetActive(false);

        yield return null;
    }
}