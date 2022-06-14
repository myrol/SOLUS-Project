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

    public int used;

    private void Start()
    {
        camera = GameObject.Find("Camera");
        player = GameObject.Find("PlayerCapsule");
        crosshair = GameObject.Find("crosshair");
        gears = GameObject.Find("Gears");
        moving = GameObject.Find("moving");
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
        if (GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().getProgress() == 2)
        {
            if (used == 0)
            {
                StartCoroutine(ExplodeCutScene());
            }
            else if (used == 3)
            {
                StartCoroutine(ElectricCutScene());
                GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().addProgress();
            }
        }
    }

    private IEnumerator ElectricCutScene()
    {
        //Start Gears, tesla, announcer and move laby
        moving.transform.localRotation = Quaternion.Euler(-45f, -90f, 0f);
        StartCoroutine(gears.GetComponent<turnGears>().turner());

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

        yield return new WaitForSeconds(7);
        //turn Camera to tesla
        float elapsed = 0.0f;
        while (elapsed < 2.0f)
        {
            player.transform.Rotate(0.0f, -0.37f, 0.0f, Space.Self);
            camera.transform.Rotate(-0.05f, 0.0f, 0.0f, Space.Self);
            player.transform.position = player.transform.position + new Vector3(0.007f, 0f, -0.007f);
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(4);

        player.transform.localRotation = Quaternion.Euler(originalPlayRot);
        camera.transform.localRotation = Quaternion.Euler(originalCamRot);
        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);
        player.transform.position = originalPlayerPos;

        used = -1;
        yield return null;
    }

    private IEnumerator ExplodeCutScene()
    {
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