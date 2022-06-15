using UnityEngine;

public class place11 : Interactable
{
    private GameObject gear11;
    private GameObject gear11_UI;
    private GameObject lever;
    public AudioClip place;

    private void Start()
    {
        gear11 = GameObject.Find("gear11");
        gear11_UI = GameObject.Find("gear11_UI");
        lever = GameObject.Find("lever");
    }
    protected override void Interact()
    {
        if (gear11_UI.activeSelf)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(place, 1f);
            gear11.SetActive(true);
            gear11_UI.SetActive(false);
            lever.GetComponent<Lever>().setUsed(1);
        }
    }
}