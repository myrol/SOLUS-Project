using UnityEngine;

public class place : Interactable
{
    public GameObject gear, gear_UI, lever, player;
    public AudioClip placeAudio;

    protected override void Interact()
    {
        if (gear_UI.activeSelf)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(placeAudio, 1f);
            gear.SetActive(true);
            gear_UI.SetActive(false);
            player.GetComponent<StoryHolder>().steampunk_lever++;
            lever.GetComponent<Lever>().loadLever();
        }
    }
}