using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private GameObject blueprint;
    [SerializeField] private Transform spawn;
    [SerializeField] private float upwardForce = 500f;
    private GameObject currentInstance;

    public void spawnInstance()
    {
        // Der jetzige soll vom Knopf aufspringen und dann erst zerstört werden
        if (currentInstance != null)
        {
            /* ColorCube Prefab
             *      -> Cube
             *            -> Collider (Hat Rigidbody Component)
             */

            Rigidbody rb = currentInstance.transform.GetChild(0).transform.GetChild(0).GetComponent<Rigidbody>();
            rb.AddForce( new Vector3(Random.Range(-200f,200f), upwardForce, Random.Range(-200f,-200f)) );
            rb.useGravity = false;
            rb.drag = 3f;
            rb.angularDrag = 0f;
            rb.AddTorque(Vector3.up * 1000f);

            StartCoroutine(destroyAfter(.5f));
        } 
        else
        {
            currentInstance = Instantiate(blueprint, spawn.position, Quaternion.identity);
        }
    }

    private IEnumerator destroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        Destroy(currentInstance);
        currentInstance = Instantiate(blueprint, spawn.position, Quaternion.identity);
    }
}
