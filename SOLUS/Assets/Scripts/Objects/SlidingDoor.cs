using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private AudioSource audio_close;
    [SerializeField] private AudioSource audio_open;
    [SerializeField] private float animationDuration_open = 1.5f;
    [SerializeField] private float animationDuration_close = 1.632f;
    [SerializeField] private float distance = 3f;
    [SerializeField] private bool startOpen = false;
    private Vector3 start;
    private Vector3 target;

    public void Awake()
    {
        start = transform.position;
        target = transform.position + Vector3.up * distance;

        if (startOpen) open();
    }

    public void open()
    {
        transform.DOMove(target, animationDuration_open).SetEase(Ease.OutCirc);

        StartCoroutine(playOpenSound());
    }

    public void close()
    {
        transform.DOMove(start, animationDuration_close).SetEase(Ease.InCirc);

        StartCoroutine(playCloseSound());
    }

    public IEnumerator playOpenSound()
    {
        audio_open.Stop();
        audio_open.Play();
        yield break;
    }

    public IEnumerator playCloseSound()
    {
        audio_close.Stop();
        audio_close.Play();
        yield break;
    }
}
