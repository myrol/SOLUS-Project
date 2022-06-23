using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    private List<Collider> cubesOnButton;
    
    public UnityEvent buttonPressed;
    public UnityEvent buttonUnpressed;

    private byte acceptedColor;

    private void Start()
    {
        cubesOnButton = new List<Collider>();

        acceptedColor = gameObject.transform.parent.GetChild(1).GetComponent<Colorable>().color;
    }

    private void OnTriggerEnter(Collider other)
    {
        Colorable c = other.gameObject.GetComponent<Colorable>();
        if (c == null && other.tag != "Player") return;

        // If it's the player or the color of the cube matches
        if(other.tag == "Player" || c.color == GameAssets.COLOR_BLACK || c.color == acceptedColor )
        {
            cubesOnButton.Add(other);

            if (cubesOnButton.Count == 1)
            {
                buttonPressed.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!cubesOnButton.Contains(other)) return;

        if (other.tag == "Player" ||
            other.gameObject.tag == "Cube")
        {
            cubesOnButton.Remove(other);

            if (cubesOnButton.Count == 0)
            {
                buttonUnpressed.Invoke();
            }
        }
    }
}