using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public AudioClip dialogueClip;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DialogueManager.Instance.AddToQueue(dialogueClip);
            Destroy(gameObject);
        }
    }
}
