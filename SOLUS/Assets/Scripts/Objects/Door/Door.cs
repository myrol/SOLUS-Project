using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;
    public AudioClip doorOpenAudio, doorCloseAudio;

    private bool opened = false;
    private Vector3 start;
    private Vector3 target;

    private float animationDuration = 2f;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = 0.3f;
        gameObject.GetComponent<AudioSource>().maxDistance = 10f;
        gameObject.GetComponent<AudioSource>().spatialBlend = 1f;
        start = transform.localEulerAngles;
        target = (openOtherWay) ? new Vector3(0f, start.y + 90f, 0f) : new Vector3(0f, start.y - 90f, 0f);
    }

    public void open()
    {
        if (opened) return;

        opened = true;
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorOpenAudio);
        transform.DOLocalRotate(target, animationDuration);
    }

    public void close()
    {
        if (!opened) return;

        opened = false;
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorCloseAudio);
        transform.DOLocalRotate(start, animationDuration);
    }
}
