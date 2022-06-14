using UnityEngine;

public class place11 : Interactable
{
    private GameObject gear11;
    private GameObject gear11_UI;
    private GameObject gear2_UI;
    private GameObject lever;

    private void Start()
    {
        gear11 = GameObject.Find("gear11");
        gear11_UI = GameObject.Find("gear11_UI");
        gear2_UI = GameObject.Find("gear2_UI");
        lever = GameObject.Find("lever");
    }
    protected override void Interact()
    {
        if (gear11_UI.activeSelf)
        {
            gear11.SetActive(true);
            gear11_UI.SetActive(false);
            lever.GetComponent<Lever>().setUsed(1);
        }
    }
}
