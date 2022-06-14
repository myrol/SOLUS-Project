using UnityEngine;

public class pickUp11 : Interactable
{
    private GameObject gear11;
    private GameObject gear11_UI;
    private GameObject lever;

    private void Start()
    {
        gear11 = GameObject.Find("gear11");
        gear11_UI = GameObject.Find("gear11_UI");
        gear11_UI.SetActive(false);
        lever = GameObject.Find("lever");
    }
    protected override void Interact()
    {
        if(lever.GetComponent<Lever>().getUsed() == 1)
        {
            gear11.transform.localPosition = new Vector3(55.898f, 2.298f, 47.729f);
            gear11.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            gear11.SetActive(false);
            gear11_UI.SetActive(true);
        }
    }
}
