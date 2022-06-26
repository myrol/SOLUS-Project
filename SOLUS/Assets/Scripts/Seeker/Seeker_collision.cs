using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Seeker_collision : MonoBehaviour
{
#pragma warning disable CS0108
    public GameObject player, deathScreen, camera, crosshair, room2, hello;
#pragma warning restore CS0108

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FadeInOutImg(deathScreen));
            StartCoroutine(FadeInOut(hello));
        }
    }
    private IEnumerator FadeInOutImg(GameObject objectUsing)
    {
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        objectUsing.SetActive(true);
        byte elapsed = 1;
        bool direction = true;
        while (elapsed != 0)
        {
            if (direction && elapsed != 255)
                elapsed++;
            else
                elapsed-=2;
            objectUsing.GetComponent<Image>().color = new Color32(0, 0, 0, elapsed);
            if (elapsed == 255)
            {
                elapsed--;
                direction = false;
                yield return new WaitForSeconds(2);
                player.transform.position = room2.transform.position;
            }
            yield return null;
        }
        objectUsing.SetActive(false);

        yield return new WaitForSeconds(0.2f);

        gameObject.GetComponent<BoxCollider>().enabled = true;
        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);

        yield return null;
    }
    private IEnumerator FadeInOut(GameObject objectUsing)
    {
        byte elapsed = 1;
        bool direction = true;
        while (elapsed != 0)
        {
            if (direction)
                elapsed++;
            else
                elapsed-=2;
            objectUsing.GetComponent<TextMeshProUGUI>().color = new Color32(255, 255, 255, elapsed);
            if (elapsed == 255)
            {
                elapsed--;
                direction = false;
                yield return new WaitForSeconds(2);
            }
            yield return null;
        }
        yield return null;
    }
}
