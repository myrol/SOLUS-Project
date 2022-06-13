using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Whiteboard : Interactable
{
    [SerializeField] private float rotateBy = 120;
    [SerializeField] private float animationDuration = 3f;

    private Transform pivot;
    private bool canRotate = false;

    public void Awake()
    {
        pivot = GetComponent<Transform>();
    }

    protected override void Interact()
    {
        canRotate = true;
    }

    public void FixedUpdate()
    {
        if (canRotate)
        {
            pivot.DOLocalRotate(new Vector3(0, pivot.localEulerAngles.y + rotateBy, 0), animationDuration).SetEase(Ease.OutCirc);
            canRotate = false;
        }
    }
}
