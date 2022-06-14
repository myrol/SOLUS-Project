using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StandingButton : Interactable
{
    public Animator anim;
    [SerializeField] public UnityEvent eve;

    void Start()
    {
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

        StartCoroutine(deactivate());
    }

    private IEnumerator deactivate()
    {
        yield return new WaitForSeconds(1);

        Debug.Log("Deactivated!");
        anim.SetTrigger("TrDeactivate");
    }
}
