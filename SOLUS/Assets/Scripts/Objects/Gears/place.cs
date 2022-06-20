using UnityEngine;

public class place : Interactable
{
    public GameObject gear;
    public GameObject gear_UI;
    public GameObject lever;
    public AudioClip placeAudio;

    protected override void Interact()
    {
        if (gear_UI.activeSelf)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(placeAudio, 1f);
            gear.SetActive(true);
            gear_UI.SetActive(false);
            lever.GetComponent<Lever>().setUsed(1);
        }
    }
}