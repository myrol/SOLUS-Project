using UnityEngine;

public class PickKeyCard : Interactable
{
    public GameObject pickObject, pickObject_UI, player;
    public AudioClip pickUpAudio;

    protected override void Interact()
    {
        pickObject.SetActive(false);
        pickObject_UI.SetActive(true);
        AudioSource source = pickObject_UI.GetComponent<AudioSource>();
        source.PlayOneShot(pickUpAudio, 1f);
    }
}