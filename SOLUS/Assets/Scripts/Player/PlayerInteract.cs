using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject cam;
    private float distance = 5f;
    public LayerMask mask;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, distance, mask))
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<Interactable>().BaseInteract();
                // Debug.Log(hit.collider.GetComponent<Interactable>().message);
            }
        }
    }
}
