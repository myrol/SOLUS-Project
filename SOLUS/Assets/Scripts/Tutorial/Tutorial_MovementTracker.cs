using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_MovementTracker : MonoBehaviour
{
    public AudioClip dialogue;

    private const long threshold = 800; // Circa 15 Sekunden rumlaufen
    private long counter = 0; // "Duration" the player holds the movement keys for

    private bool active = false;

    public void activate()
    {
        active = true;        
    }

    private void Update()
    {
        if (active == false) return;

        if (movementKeyPressed()) counter++;

        if (counter >= threshold)
        {
            DialogueManager.Instance.AddToQueue(dialogue);
            Destroy(gameObject);
        }
    }

    private bool movementKeyPressed()
    {
        return (
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.D)
        );
    }
}
