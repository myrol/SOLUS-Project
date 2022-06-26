using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : MonoBehaviour      //Abstrakt damit man es für verschiedene Rätsel benutzen kann
{
    private Rigidbody rb;
    private Transform carryPosition;
    private float restedThreshold = .5f;
    private float fallingThreshold = 20f;
    public bool pickedUp = false;

    private Vector3 lastRestedPosition;

    private void Awake()
    {
        carryPosition = GameObject.Find("PickUp").transform;
        rb = GetComponent<Rigidbody>();    
    }

    public void PickUp()
    {
        rb.useGravity = false;
        rb.drag = 15;
        rb.angularDrag = 5;
    }
    public void Drop()
    {
        rb.drag = 1;
        rb.angularDrag = 1;
        rb.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude <= restedThreshold)
        {
            lastRestedPosition = transform.position;
        }

        if (pickedUp)
        {
            Vector3 target = carryPosition.position;
            float dist = Vector3.Distance(target, transform.position);
            if (dist > 0.01f)
            {
                Vector3 dir = target - transform.position;
                rb.AddForce(dir * 250);
            }
        }

        // If it falls off the map, reset position to where the object lastly rested
        if (transform.position.y < lastRestedPosition.y - fallingThreshold)
        {
            transform.position = lastRestedPosition;
            rb.velocity = Vector3.zero;
        }
    }
}
