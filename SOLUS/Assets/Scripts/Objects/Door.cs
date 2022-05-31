using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool canOpen = false;
    private float speed = 1f;
    public void open()
    {
        canOpen = true;
    }
    private void FixedUpdate()
    {
        if (canOpen == false) return;

        if (transform.localRotation.y < 0.7071)
        {
            transform.Rotate(new Vector3(0, 1, 0));
        }
    }
}
