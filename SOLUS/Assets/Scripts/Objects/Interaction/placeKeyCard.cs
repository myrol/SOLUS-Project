using UnityEngine;
using UnityEngine.Events;

public class placeKeyCard : Interactable
{
    public GameObject keycard_placeholder, keycard_UI, player, keycard_placeholder_test1, keycard_placeholder_test2;
    public AudioClip placeAudio;
    [SerializeField] private UnityEvent eve;

    private void Start()
    {
        keycard_placeholder.SetActive(false);
    }

    protected override void Interact()
    {
        if (keycard_UI.activeSelf)
        {
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.PlayOneShot(placeAudio, 1f);
            keycard_placeholder.SetActive(true);
            keycard_UI.SetActive(false);
            if (keycard_placeholder_test1.activeSelf && keycard_placeholder_test2.activeSelf)
            {
                eve.Invoke();
            }
        }
    }
}