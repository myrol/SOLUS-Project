using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class turnGelaender : MonoBehaviour
{
    public void turn()
    {
        transform.DOLocalRotate(new Vector3(-90f, 0, 0), 1f);
    }
}
