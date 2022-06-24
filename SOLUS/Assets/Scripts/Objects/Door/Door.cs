using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;
    public AudioClip doorOpenAudio, doorCloseAudio;

    private Vector3 start;
    private Vector3 target;

    private float animationDuration = 2f;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = 0.3f;
        start = transform.localEulerAngles;
        target = (openOtherWay) ? new Vector3(0f, start.y + 90f, 0f) : new Vector3(0f, start.y - 90f, 0f);
    }

    public void open()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorOpenAudio);
        transform.DOLocalRotate(target, animationDuration);
    }

    public void close()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(doorCloseAudio);
        transform.DOLocalRotate(start, animationDuration);
    }
}
