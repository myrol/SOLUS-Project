using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    [SerializeField] private List<GameObject> loadLocations, deloadLocations;

    private void OnTriggerEnter(Collider other)
    {
        LoadManager.Instance.load(loadLocations);
        LoadManager.Instance.deload(deloadLocations);
    }
}
