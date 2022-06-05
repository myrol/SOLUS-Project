using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public GameObject cam;
    private Carryable item;
    private float distance = 2.25f;
    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (item != null && item.pickedUp)
            {
                item.Drop();
                item.pickedUp = false;
                return;
            }
            else if (Physics.Raycast(ray, out hit, distance, mask))
            {
                item = hit.collider.GetComponent<Carryable>();
                item.pickedUp = true;

                item.PickUp();
            }
        }
    }
}
