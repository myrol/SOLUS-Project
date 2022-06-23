using UnityEngine;

public class placeKeyCard : Interactable
{
    public GameObject keycard, keycard_UI, player;
    public AudioClip placeAudio;

    protected override void Interact()
    {
        if (keycard_UI.activeSelf)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(placeAudio, 1f);
            keycard.SetActive(true);
            keycard_UI.SetActive(false);
        }
    }
}