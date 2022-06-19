using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockerDoor : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;

    private bool isOpen;
    private Vector3 start;
    private Vector3 target;

    private float animationDuration = 1.5f;

    private void Awake()
    {
        start = transform.localEulerAngles;
        target = (openOtherWay) ? new Vector3(0f, start.y + 90f, 0f) : new Vector3(0f, start.y - 90f, 0f);
        isOpen = false;
    }

    public void open()
    {
        if(!isOpen)
        {
            transform.DOLocalRotate(target, animationDuration);
            isOpen = true;
        }
        else
        {
            transform.DOLocalRotate(start, animationDuration);
            isOpen = false;
        }
    }
}
