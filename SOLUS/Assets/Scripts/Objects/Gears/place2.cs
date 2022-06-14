using UnityEngine;

public class place2 : Interactable
{
    private GameObject gear2;
    private GameObject gear2_UI;
    private GameObject gear11_UI;
    private GameObject lever;

    private void Start()
    {
        gear2 = GameObject.Find("gear2");
        gear2_UI = GameObject.Find("gear2_UI");
        gear11_UI = GameObject.Find("gear11_UI");
        lever = GameObject.Find("lever");
    }
    protected override void Interact()
    {
        if (gear2_UI.activeSelf)
        {
            gear2.SetActive(true);
            gear2_UI.SetActive(false);
            lever.GetComponent<Lever>().setUsed(1);
        }
    }
}