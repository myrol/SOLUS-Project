using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeButton : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField]
    private float goDownBy = 0.1f;

    public void activate()
    {
        if (isActive == true) return;

        isActive = true;
        transform.localPosition += Vector3.down * goDownBy;
    }

    public void deactivate()
    {
        if (isActive == false) return;

        isActive = false;
        transform.localPosition += Vector3.up * goDownBy;
    }
}
