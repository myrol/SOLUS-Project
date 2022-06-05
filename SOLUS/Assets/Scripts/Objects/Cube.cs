using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Carryable
{
    public Rigidbody rb;
    public MeshRenderer meshRenderer;
    public Transform carryPosition;
    private Transform originalParent;

    private const string MATERIAL_PATH = "Materials/Room1/Button/";

    [SerializeField]
    [Range(0,3)]
    public byte color;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalParent = transform.parent;
        changeColor(color);
    }
    private void changeColor(byte _color)
    {
        switch (color)
        {
            case 0:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "black");
                break;
            case 1:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "blue");
                break;
            case 2:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "green");
                break;
            case 3:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "red");
                break;
        }
    }
    public override void PickUp()
    {
        rb.useGravity = false;
        rb.drag = 20;
    }

    public override void Drop()
    {
        rb.drag = 1;
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