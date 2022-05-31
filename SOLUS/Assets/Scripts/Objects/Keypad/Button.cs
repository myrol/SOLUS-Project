using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : Interactable
{
    [SerializeField]
    private UnityEvent onClicked;
    protected override void Interact()
    {
        onClicked.Invoke();
    }
}
