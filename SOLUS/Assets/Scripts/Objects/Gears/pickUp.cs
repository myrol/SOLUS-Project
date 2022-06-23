using UnityEngine;

public class pickUp : Interactable
{
    public GameObject pickObject, pickObject_UI, player;
    private Vector3 originalLocation;
    private Quaternion originalRotation;
    public AudioClip pickUpAudio;

    private void Start()
    {
        originalLocation = pickObject.transform.localPosition;
        originalRotation = pickObject.transform.localRotation;

    }

    protected override void Interact()
    {
        if (player.GetComponent<StoryHolder>().steampunk_lever == 1 || player.GetComponent<StoryHolder>().steampunk_lever == 2 && transform.eulerAngles.x !=0)
        {
            pickObject.transform.localPosition = originalLocation;
            pickObject.transform.localRotation = originalRotation;
            pickObject.SetActive(false);
            pickObject_UI.SetActive(true);
            AudioSource source = pickObject_UI.GetComponent<AudioSource>();
            source.PlayOneShot(pickUpAudio, 1f);
        }
    }
}