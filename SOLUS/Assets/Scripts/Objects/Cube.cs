using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    public Rigidbody rb;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    protected override void Interact()
    {
        rb.velocity = Vector3.up * 5;
    }
}
