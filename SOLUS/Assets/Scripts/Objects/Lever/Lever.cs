using System.Collections;
using UnityEngine;

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

    private void Start()
    {
        camera = GameObject.Find("Camera");
        player = GameObject.Find("PlayerCapsule");
        crosshair = GameObject.Find("crosshair");
        gears = GameObject.Find("Gears");
    }

    public int getUsed()
    {
        return used;
    }
    public void setUsed(int setter)
    {
        used += setter;
        if (used == 3)
        {
            moving.transform.localRotation = Quaternion.Euler(45f, -90f, 0f);
        }
    }

    protected override void Interact()
    {

        if (used == 0)
        {
            StartCoroutine(SteampunkCutScene());
        }
        else if (used == 3)
        {
            used = -1;
            //Start Gears, tesla, announcer and move laby
            StartCoroutine(gears.GetComponent<turnGears>().turner());
        }
    }

    private IEnumerator SteampunkCutScene()
    {
        moving = GameObject.Find("moving");
        //moving.transform.Rotate((-90.0f), 0.0f, 0.0f, Space.Self);
        moving.transform.localRotation = Quaternion.Euler(-45f, -90f, 0f);

        Vector3 originalPlayerPos = player.transform.position;
        Vector3 originalPlayRot = player.transform.localEulerAngles;
        Vector3 originalCamRot = camera.transform.localEulerAngles;

        //Disable Camera- and Player-movement and Cursor
        player.transform.position = new Vector3(50.56f, 0.09f, 27.61f);
        player.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);

        //Start gears
        StartCoroutine(gears.GetComponent<turnGears>().Explode());
        yield return new WaitForSeconds(5);
        //explode gears
        StartCoroutine(camera.GetComponent<CameraShake>().Shake(.3f, .2f));

        yield return new WaitForSeconds(2);

        player.transform.localRotation = Quaternion.Euler(originalPlayRot);
        camera.transform.localRotation = Quaternion.Euler(originalCamRot);
        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);
        player.transform.position = originalPlayerPos;
        used = 1;
        yield return null;
    }
}