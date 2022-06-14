using UnityEngine;

public class pickUp2 : Interactable
{
    private GameObject gear2;
    private GameObject gear2_UI;
    private GameObject lever;

    private void Start()
    {
        gear2 = GameObject.Find("gear2");
        gear2_UI = GameObject.Find("gear2_UI");
        gear2_UI.SetActive(false);
        lever = GameObject.Find("lever");
    }
    protected override void Interact()
    {
        if (lever.GetComponent<Lever>().getUsed() == 1 || lever.GetComponent<Lever>().getUsed() == 2)
        {
            gear2.transform.localPosition = new Vector3(53.888f, 2.199f, 47.762f);
            gear2.transform.localRotation = Quaternion.Euler(0f, 0f, 5.04f);
            gear2.SetActive(false);
            gear2_UI.SetActive(true);
        }
    }
}