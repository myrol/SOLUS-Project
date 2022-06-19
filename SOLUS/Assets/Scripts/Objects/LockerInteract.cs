using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LockerInteract : Interactable
{
    [SerializeField] public UnityEvent eve;

    protected override void Interact()
    {
        eve.Invoke();
    }
}
