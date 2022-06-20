using System.Collections;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] public int used;

#pragma warning disable CS0108
    [SerializeField] private GameObject camera, moving, crosshair, gears, room_0, player, cutScenePos, endScenePos;
#pragma warning restore CS0108
    private Quaternion playerEndRot;
    private Quaternion camEndRot;

    [SerializeField] private AudioClip upAudio, downAudio;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
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
            source.PlayOneShot(upAudio, 1f);
            moving.transform.localRotation = Quaternion.Euler(45f, -90f, 0f);
        }
    }

    protected override void Interact()
    {
        if (room_0.GetComponent<SteampunkStoryHolder>().getProgress() == 2)
        {
            if (used == 0)
            {
                StartCoroutine(ExplodeCutScene());
            }
            else if (used == 3)
            {
                StartCoroutine(ElectricCutScene());
                room_0.GetComponent<SteampunkStoryHolder>().addProgress();
            }
        }
        else if (moving.transform.eulerAngles.x == 315f)
        {
            StartCoroutine(leverFail());
        }
    }
    private IEnumerator leverFail()
    {
        float elapsed = 0.0f;
        float direction = -1f;
        source.PlayOneShot(downAudio, 1f);
        while (elapsed < 180f)
        {
            moving.transform.Rotate((0.5f * direction), 0.0f, 0.0f, Space.Self);
            elapsed += 0.5f;
            if (direction == -1f && elapsed >= 90f)
            {
                source.PlayOneShot(upAudio, 1f);
                direction = 1f;
            }
            yield return null;
        }
        moving.transform.localRotation = Quaternion.Euler(45f, -90f, 0f);
        yield return null;
    }

    private IEnumerator ElectricCutScene()
    {
        //Start Gears, tesla, announcer and move laby
        float elapsed = 0.0f;
        float direction = -1f;
        source.PlayOneShot(downAudio, 1f);
        while (elapsed < 90f)
        {
            moving.transform.Rotate((0.5f * direction), 0.0f, 0.0f, Space.Self);
            elapsed += 0.5f;
            yield return null;
        }

        endScenePos.transform.position = player.transform.position;
        playerEndRot = player.transform.localRotation;
        camEndRot = camera.transform.localRotation;

        StartCoroutine(gears.GetComponent<turnGears>().turner());

        //Disable Camera- and Player-movement and Cursor
        player.transform.position = cutScenePos.transform.position;
        player.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);
        moving.transform.localRotation = Quaternion.Euler(-45f, -90f, 0f);

        yield return new WaitForSeconds(7);
        //turn Camera to tesla
        elapsed = 0.0f;
        while (elapsed < 2.5f)
        {
            if (player.transform.rotation.y >= -0.9019078)
            {
                player.transform.Rotate(0.0f, -0.38f, 0.0f, Space.Self);
            }
            if (camera.transform.rotation.x >= -0.06365685)
            {
                camera.transform.Rotate(-0.06f, 0.0f, 0.0f, Space.Self);
            }
            if (player.transform.position.x < 49.9118f && player.transform.position.z > -20.6618f)
            {
                player.transform.position = player.transform.position + new Vector3(0.008f, 0f, -0.008f);
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(4);

        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        player.transform.localRotation = playerEndRot;
        camera.transform.localRotation = camEndRot;
        player.transform.position = endScenePos.transform.position;

        used = -1;

        AudioSource audioSource = GameObject.Find("furnace").GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource = GameObject.Find("Steam_Player").GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource = GameObject.Find("Water_Player_2").GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.volume = 0.1f;
        yield return null;
    }

    private IEnumerator ExplodeCutScene()
    {
        float elapsed = 0.0f;
        float direction = -1f;
        source.PlayOneShot(downAudio, 1f);
        while (elapsed < 90f)
        {
            moving.transform.Rotate((0.5f * direction), 0.0f, 0.0f, Space.Self);
            elapsed += 0.5f;
            yield return null;
        }

        endScenePos.transform.position = player.transform.position;
        playerEndRot = player.transform.localRotation;
        camEndRot = camera.transform.localRotation;

        //Disable Camera- and Player-movement and Cursor
        player.transform.position = cutScenePos.transform.position;
        player.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        camera.GetComponent<CameraMovement>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        crosshair.SetActive(false);
        moving.transform.localRotation = Quaternion.Euler(-45f, -90f, 0f);

        //Start gears
        StartCoroutine(gears.GetComponent<turnGears>().Explode());
        yield return new WaitForSeconds(5);
        //explode gears
        StartCoroutine(camera.GetComponent<CameraShake>().Shake(.3f, .2f));

        yield return new WaitForSeconds(2);

        camera.GetComponent<CameraMovement>().enabled = true;
        player.GetComponent<Movement>().enabled = true;
        crosshair.SetActive(true);
        player.transform.localRotation = playerEndRot;
        camera.transform.localRotation = camEndRot;
        player.transform.position = endScenePos.transform.position;
        used = 1;
        yield return null;
    }
}