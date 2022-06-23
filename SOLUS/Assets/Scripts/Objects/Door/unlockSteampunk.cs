using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class unlockSteampunk : Interactable
{
    [SerializeField] private UnityEvent eve;
    public GameObject player, steampunk_key_ui;

    public void loadDoors()
    {
        if(player.GetComponent<StoryHolder>().steampunk > -1)
        {
            eve.Invoke();
            Destroy(gameObject);
        }
    }

    protected override void Interact()
    {
        if (player.GetComponent<StoryHolder>().steampunk == -1 && steampunk_key_ui.activeSelf)
        {
            GameObject.Find("ROOM 1").SetActive(false);
            GameObject.Find("ROOM 2").SetActive(false);
            GameObject.Find("ROOM 3").SetActive(true);
            GameObject.Find("TutorialNeu").SetActive(false);
            player.GetComponent<StoryHolder>().steampunk++;
            steampunk_key_ui.SetActive(false);
            eve.Invoke();
            Destroy(gameObject);
        }
    }
}