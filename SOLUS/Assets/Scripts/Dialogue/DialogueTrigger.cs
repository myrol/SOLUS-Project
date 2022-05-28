using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioClip dialogueClip;
    
    private void OnTriggerEnter(Collider other)
    {
        DialogueManager.Instance.AddToQueue(dialogueClip);
        Destroy(gameObject);
    }
}
