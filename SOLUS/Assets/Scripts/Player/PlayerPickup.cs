using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject cam;
    private Carryable item;
    private float distance = 2.25f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }
    }

    void interact()
    {
        if (item != null && item.pickedUp)
        {
            item.Drop();
            item.pickedUp = false;
            item = null;
            return;
        }

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            int objLayer = hit.collider.gameObject.layer;

            if (objLayer == 8) // Carryables
            {
                item = hit.collider.GetComponent<Carryable>();
                item.pickedUp = true;

                item.PickUp();
            }
        }
    }
}
