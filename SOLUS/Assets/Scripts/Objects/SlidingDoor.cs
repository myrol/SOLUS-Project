using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1.5f;
    [SerializeField] private float distance = 3f;
    private Vector3 start;
    private Vector3 target;

    public void Awake()
    {
        start = transform.position;
        target = transform.position + Vector3.up * distance;
    }

    public void open()
    {
        transform.DOMove(target, animationDuration).SetEase(Ease.OutCirc);
    }

    public void close()
    {
        transform.DOMove(start, animationDuration).SetEase(Ease.OutCirc);
    }
}
