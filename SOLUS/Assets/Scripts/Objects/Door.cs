using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;

    private Vector3 start;
    private Vector3 target;

    private float animationDuration = 3f;

    private void Awake()
    {
        start = transform.localEulerAngles;
        target = (openOtherWay) ? new Vector3(0f, start.y + 90f, 0f) : new Vector3(0f, start.y - 90f, 0f);
    }

    public void open()
    {
        transform.DOLocalRotate(target, animationDuration);
    }

    public void close()
    {
        transform.DOLocalRotate(start, animationDuration);
    }
}
