using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{

    [SerializeField] private bool reset;
#pragma warning disable CS0108
    [SerializeField] private GameObject player, crosshair, trigger_2, camera;
#pragma warning restore CS0108

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //Locked die Maus am Anfang des Spiels

        if (reset)
        {
            player.GetComponent<StoryHolder>().resetSteampunk();
            trigger_2.SetActive(false);

            Debug.Log("Startup");
            //Canvas black
            StartCoroutine(startupRountine());
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

        yield return new WaitForSeconds(11);
        //Start screen visibility
        yield return new WaitForSeconds(2.5f);

        float elapsed = 0.0f;
        while (elapsed < 90f)
        {
            camera.transform.Rotate(0.06f, 0f, 0.0f, Space.Self);
            player.transform.position += new Vector3(0.0014267f, 0.00167f, 0f);
            elapsed += 0.12f;
            yield return null;
        }
        player.transform.position = new Vector3(16.7f, 17.85f, -22.2f);
        yield return new WaitForSeconds(18);

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
