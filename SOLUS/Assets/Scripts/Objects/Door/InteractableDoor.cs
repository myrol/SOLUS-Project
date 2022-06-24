using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : Interactable
{
    [SerializeField] private List<GameObject> requiredKeycards;
    private Door script;

    private void Awake()
    {
        script = gameObject.GetComponent<Door>();
    }

    protected override void Interact()
    {
        // Iteriere durch alle keycards. Falls einer von denen nicht aufgesammelt wurde: brich ab.
        foreach (GameObject k in requiredKeycards)
        {
            if (!k.activeSelf) return;
        }
        
        script.open();
    }
}
