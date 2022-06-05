using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Interactable
{
    public Rigidbody rb;
    public MeshRenderer meshRenderer;
    public Transform player;
    private Transform originalParent;

    private bool isGrabbed = false;

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
    protected override void Interact()
    {
        if (isGrabbed)
        {
            transform.SetParent(originalParent);
            rb.isKinematic = false;
            rb.useGravity = true;
            isGrabbed = false;
        } 
        else
        {
            transform.SetParent(player);
            rb.isKinematic = true;
            rb.useGravity = false;
            isGrabbed = true;
        }
    }
}