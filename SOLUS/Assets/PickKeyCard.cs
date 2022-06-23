using UnityEngine;

public class PickKeyCard : Interactable
{
    public GameObject pickObject, pickObject_UI, player, toPlace;
    public AudioClip pickUpAudio;

    protected override void Interact()
    {
        if (player.GetComponent<StoryHolder>().steampunk_lever == 4 && player.GetComponent<StoryHolder>().steampunk == 3)
        {
            pickObject.transform.localPosition = toPlace.transform.localPosition;
            pickObject.transform.localRotation = toPlace.transform.localRotation;
            pickObject.SetActive(false);
            pickObject_UI.SetActive(true);
            AudioSource source = pickObject_UI.GetComponent<AudioSource>();
            source.PlayOneShot(pickUpAudio, 1f);
        }
    }
}