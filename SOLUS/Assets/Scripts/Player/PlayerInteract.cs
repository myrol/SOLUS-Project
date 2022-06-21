using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float distance = 2.5f;
    private Carryable item;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            castRay();
        }
    }

    void castRay()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance))
        {
            int objLayer = hit.collider.gameObject.layer;
            if (objLayer == 7) // Interactables
            {
                hit.collider.GetComponent<Interactable>().BaseInteract();
            }
        }
    }
}
