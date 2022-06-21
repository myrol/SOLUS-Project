using UnityEngine;

public class pickUp : Interactable
{
    public GameObject gear;
    public GameObject gear_UI;
    public GameObject player;
    private Vector3 originalLocation;
    private Quaternion originalRotation;
    public AudioClip pickUpAudio;

    private void Start()
    {
        originalLocation = gear.transform.localPosition;
        originalRotation = gear.transform.localRotation;
        gear_UI.SetActive(false);

    }
    protected override void Interact()
    {
        if (player.GetComponent<StoryHolder>().getSteampunkLever() == 1 || player.GetComponent<StoryHolder>().getSteampunkLever() == 2)
        {
            gear.transform.localPosition = originalLocation;
            gear.transform.localRotation = originalRotation;
            gear.SetActive(false);
            gear_UI.SetActive(true);
            AudioSource source = gear_UI.GetComponent<AudioSource>();
            source.PlayOneShot(pickUpAudio, 1f);
        }
    }
}