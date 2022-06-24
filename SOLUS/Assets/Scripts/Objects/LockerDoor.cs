using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LockerDoor : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;
    public AudioClip doorOpenAudio, doorCloseAudio;

    private bool isOpen;
    private Vector3 start;
    private Vector3 target;

    private float animationDuration = 1.5f;

    private void Awake()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = 0.3f;
        gameObject.GetComponent<AudioSource>().maxDistance = 10f;
        gameObject.GetComponent<AudioSource>().spatialBlend = 1f;
        start = transform.localEulerAngles;
        target = (openOtherWay) ? new Vector3(0f, start.y + 90f, 0f) : new Vector3(0f, start.y - 90f, 0f);
        isOpen = false;
    }

    public void open()
    {
        if(!isOpen)
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(doorOpenAudio);
            transform.DOLocalRotate(target, animationDuration);
            isOpen = true;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(doorCloseAudio);
            transform.DOLocalRotate(start, animationDuration);
            isOpen = false;
        }
    }
}
