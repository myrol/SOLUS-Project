using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera cam;
    private float distance = 3f;
    public LayerMask mask;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, mask))
        {
            Debug.Log(hit.collider.GetComponent<Interactable>().message);
        }
    }
}
