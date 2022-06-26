using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiveFeed : Interactable
{

    [SerializeField] public UnityEvent eve;
    // Start is called before the first frame update
    protected override void Interact()
    {
        activate();
    }

    private void activate()
    {
        eve.Invoke();   
    }
}

