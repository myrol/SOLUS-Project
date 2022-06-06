using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private float animationDuration = 1.5f;
    [SerializeField] private Transform target, original;

    public void open()
    {
        transform.DOMove(target.position, animationDuration).SetEase(Ease.OutCirc);
    }

    public void close()
    {
        transform.DOMove(original.position, animationDuration).SetEase(Ease.OutCirc);
    }
}
