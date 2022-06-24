using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deloadSteampunk : MonoBehaviour
{
    [SerializeField] private List<GameObject> loadLocations, deloadLocations;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        externTrigger();
    }

    public void externTrigger()
    {
        if(player.GetComponent<StoryHolder>().steampunk == 3)
        {
            LoadManager.Instance.load(loadLocations);
            LoadManager.Instance.deload(deloadLocations);
        }
    }
}
