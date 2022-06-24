using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField] private GameObject ui;
    private Door script;

    private void Awake()
    {
        script = gameObject.GetComponent<Door>();
    }

    protected override void Interact()
    {
        if (ui.activeSelf)
        {
            script.open();
        }
    }
}
