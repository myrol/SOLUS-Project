using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandingButton : Interactable
{
    public Animator anim;
    [SerializeField] public UnityEvent eve;
    public AudioClip but_down;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        anim = GetComponent<Animator>();    
    }
    protected override void Interact()
    {
        activate();
    }

    private void activate()
    {
        Debug.Log("Activated!");
        anim.SetTrigger("TrActivate");
        eve.Invoke();
        gameObject.GetComponent<AudioSource>().PlayOneShot(but_down);
        StartCoroutine(deactivate());
    }

    private IEnumerator deactivate()
    {
        Debug.Log("Deactivated!");
        anim.SetTrigger("TrDeactivate");
        yield return null;
    }
}
