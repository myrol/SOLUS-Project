using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlatformMove : MonoBehaviour
{
    private bool canMove = false;

    private float speed = 4f;

    public void moveDown()
    {
        canMove = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

    public void FixedUpdate()
    {
        if (canMove == false || transform.position.y < 0) return;

        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
