using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float distance = 2.5f;
    private Carryable item;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            castRay();
        }
    }

    void castRay()
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
            Debug.Log("Hit " + hit.collider.name);
            int objLayer = hit.collider.gameObject.layer;
            if (objLayer == 7) // Interactables
            {
                hit.collider.GetComponent<Interactable>().BaseInteract();
            }

            else if (objLayer == 8) // Carryables
            {
                item = hit.collider.GetComponent<Carryable>();
                item.pickedUp = true;

                item.PickUp();
            }
        }
    }
}
