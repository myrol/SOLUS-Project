using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDialogue : MonoBehaviour
{
    public AudioClip dialogueClip;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DialogueManager.Instance.BeginDialogue(dialogueClip);
        }
    }
}
