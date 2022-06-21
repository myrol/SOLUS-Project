using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalSprayer : MonoBehaviour
{
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject decal;
    private GameObject clone;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, GameAssets.RAYCAST_DISTANCE))
            {
                if (hit.collider.gameObject.tag == "Sprayable")
                {
                    if (clone != null) Destroy(clone);
                    clone = Instantiate(decal, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    }
}
