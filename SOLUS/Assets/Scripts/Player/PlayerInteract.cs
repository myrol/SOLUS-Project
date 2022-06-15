using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private float distance = 2.5f;

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
            if (hit.collider.gameObject.layer == 7) // Interactables
            {
                Debug.Log("Hit Interactable");
                hit.collider.GetComponent<Interactable>().BaseInteract();
            }
        }
    }
}
