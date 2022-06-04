using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    public Rigidbody rb;
    public Transform player;
    private Transform originalParent;

    private bool isGrabbed = false;

    [SerializeField]
    public byte color;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
    }
    protected override void Interact()
    {
        if (isGrabbed)
        {
            rb.useGravity = true;
            transform.SetParent(originalParent);
            isGrabbed = false;
        } 
        else
        {
            rb.useGravity = false;
            transform.SetParent(player);
            isGrabbed = true;
        }
    }
}