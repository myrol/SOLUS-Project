using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    private const byte BLACK = 0;
    private const byte BLUE = 1;
    private const byte GREEN = 2;
    private const byte RED = 3;

    [SerializeField]
    private byte color;
    
    public LayerMask interactablesLayer;
    public UnityEvent buttonPressed;
    public UnityEvent buttonUnpressed;
    private void OnTriggerEnter(Collider other)
    {
        Cube c = other.gameObject.GetComponent<Cube>();
        if (c == null && other.tag != "Player") return;

        // If it's the player or the color of the cube matches
        if(other.tag == "Player" || c.color == BLACK || c.color == color )
        {
            buttonPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" ||
            other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            buttonUnpressed.Invoke();
        }
    }
}