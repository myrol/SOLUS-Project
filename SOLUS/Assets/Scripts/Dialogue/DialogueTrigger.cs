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
            sendToManager();
        }
    }

    public void remotePlay()
    {
        sendToManager();
    }

    private void sendToManager()
    {
        DialogueManager.Instance.AddToQueue(dialogueClip);
        Destroy(gameObject);
    }
}
