using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private bool openOtherWay = false;

    private bool canOpen = false;
    private float animationDuration = 3f;
    public void open()
    {
        if (!openOtherWay)
        {
            transform.DOLocalRotate(new Vector3(0f, transform.localEulerAngles.y + 90f, 0f), animationDuration);
        }
        else
        {
            transform.DOLocalRotate(new Vector3(0f, transform.localEulerAngles.y - 90f, 0f), animationDuration);
        }
    }
}
