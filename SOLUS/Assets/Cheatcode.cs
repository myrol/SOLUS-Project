using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cheatcode : MonoBehaviour
{
#pragma warning disable CS0108
    public GameObject card_UI_blue, card_UI_green, card_UI_red, player, camera, spawn_tp;
#pragma warning restore CS0108
    [SerializeField] private UnityEvent eve1;
    [SerializeField] private UnityEvent eve2;
    public int a = 0, b = 0, c = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F3) && Input.GetKeyDown(KeyCode.F9))
        {
            StartCoroutine(tpHome());
            Debug.Log("F9 key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.F3) && Input.GetKeyDown(KeyCode.F10) && a == 0)
        {
            card_UI_blue.SetActive(true);
            eve1.Invoke();
            a = 1;
            Debug.Log("F10 key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.F3) && Input.GetKeyDown(KeyCode.F11) && b == 0)
        {
            card_UI_green.SetActive(true);
            eve2.Invoke();
            b = 1;
            Debug.Log("F11 key was pressed.");
        }
        if (Input.GetKeyDown(KeyCode.F3) && Input.GetKeyDown(KeyCode.F12) && c == 0)
        {
            card_UI_red.SetActive(true);
            c = 1;
            Debug.Log("F12 key was pressed.");
        }
    }
    private IEnumerator tpHome()
    {
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;

        yield return new WaitForSeconds(0.2f);
        player.transform.position = spawn_tp.transform.position;

        yield return new WaitForSeconds(0.2f);

        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;

        yield return null;
    }
}
