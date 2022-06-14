using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carryable : MonoBehaviour      //Abstrakt damit man es für verschiedene Rätsel benutzen kann
{
    private Rigidbody rb;
    private Transform carryPosition;
    public bool pickedUp = false;

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
    }
}
