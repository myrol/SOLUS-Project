using UnityEngine;
using System.Collections;

public class Lever : Interactable
{

#pragma warning disable CS0108
    private GameObject camera;
#pragma warning restore CS0108

    private GameObject moving;
    private GameObject player;
    private GameObject crosshair;
    private GameObject gears;
    private int used = 0;

    protected override void Interact()
    {
        camera = GameObject.Find("Camera");
        player = GameObject.Find("PlayerCapsule");
        crosshair = GameObject.Find("crosshair");
        gears = GameObject.Find("Gears");

        if (used == 0)
        {
            StartCoroutine(SteampunkCutScene());
        }
        else if (used == 2)
        {
            used = -1;
            //Start Gears, tesla, announcer and move laby
        }
    }

    private IEnumerator SteampunkCutScene()
    {
        moving = GameObject.Find("moving");
        moving.transform.Rotate((-90.0f), 0.0f, 0.0f, Space.Self);
        used = 1;

        Vector3 originalPlayerPos = player.transform.position;
        Vector3 originalPlayRot = player.transform.localEulerAngles;
        Vector3 originalCamRot = camera.transform.localEulerAngles;

        //Disable Camera- and Player-movement and Cursor
        //player.transform.position = new Vector3(50.56f, 1.3f, 27.61f);
        player.transform.position = new Vector3(50.56f, 0.09f, 27.61f);
        player.transform.Rotate(-originalPlayRot.x, -originalPlayRot.y, -originalPlayRot.z, Space.Self);
        camera.transform.Rotate(-originalCamRot.x, -originalCamRot.y, -originalCamRot.z, Space.Self);
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);

        //Start gears
        StartCoroutine(gears.GetComponent<turnGears>().Explode());
        yield return new WaitForSeconds(5);
        //explode gears
        StartCoroutine(camera.GetComponent<CameraShake>().Shake(.3f, .4f));
        yield return new WaitForSeconds(2);

        player.transform.Rotate(originalPlayRot.x, originalPlayRot.y, originalPlayRot.z, Space.Self);
        camera.transform.Rotate(originalCamRot.x, originalCamRot.y, originalCamRot.z, Space.Self);
        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);
        player.transform.localPosition = originalPlayerPos;
        player.transform.position = originalPlayerPos;
        yield return null;
    }
}