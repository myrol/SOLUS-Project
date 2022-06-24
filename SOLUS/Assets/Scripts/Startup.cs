using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Startup : MonoBehaviour
{
    [SerializeField] private float animationDuration = 15f;
    [SerializeField] private bool reset;
#pragma warning disable CS0108
    [SerializeField] private GameObject player, crosshair, trigger_2, camera, credits, seekers;
#pragma warning restore CS0108

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("gear2_UI").SetActive(false);
        GameObject.Find("gear11_UI").SetActive(false);
        GameObject.Find("steampunk_key_ui").SetActive(false);
        GameObject.Find("cubes_keycard_ui").SetActive(false);
        GameObject.Find("office_keycard_ui").SetActive(false);
        GameObject.Find("steampunk_keycard_ui").SetActive(false);
        GameObject.Find("intro_success").SetActive(false);
        GameObject.Find("death").SetActive(false); 

        if (reset)
        {
            reset = false;
            credits.GetComponent<CreditRoll>().roll();
            player.GetComponent<StoryHolder>().resetSteampunk();
            trigger_2.SetActive(false);
            seekers.SetActive(false);

            //Canvas black
            StartCoroutine(startupRountine());
        }
        else
        {
            credits.SetActive(false);
        }
    }

    private IEnumerator startupRountine()
    {
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);

        player.transform.position = new Vector3(15.63f, 16.6f, -22.2f);
        player.transform.localRotation = Quaternion.Euler(0f, 90f, 0f);
        camera.transform.localRotation = Quaternion.Euler(-45f, 0f, 0f);

        // Screen fades in
        yield return new WaitForSeconds(13.5f);
        // Screen visible

        // Wakeup animation
        player.transform.DOMove(new Vector3(16.70f, 17.85f, -22.2f), animationDuration);
        camera.transform.DOLocalRotate(new Vector3(0, 0, 0), animationDuration);
        yield return new WaitForSeconds(animationDuration);

        camera.GetComponent<CameraMovement>().enabled = true;
        crosshair.SetActive(true);

        while (true)
        {
            if(player.transform.localEulerAngles.y >= 92f || player.transform.localEulerAngles.y <= 88f)
            {
                trigger_2.SetActive(true);
                break;
            }
            yield return null;
        }

        player.GetComponent<Movement>().enabled = true;

        yield return null;
    }
}
