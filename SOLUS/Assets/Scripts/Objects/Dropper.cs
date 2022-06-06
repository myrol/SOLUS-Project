using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] private GameObject blueprint;
    private GameObject currentInstance;

    public void spawnInstance()
    {
        if (currentInstance != null)
        {
            Destroy(currentInstance);
        }
        currentInstance = Instantiate(blueprint, transform.position, Quaternion.identity);
    }
}
