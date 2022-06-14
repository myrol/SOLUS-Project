using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class moveValve : Interactable
{
    public UnityEvent onInteract;

    protected override void Interact()
    {
        onInteract.Invoke();
    }
}