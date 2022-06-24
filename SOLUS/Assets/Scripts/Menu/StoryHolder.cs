using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StoryHolder : MonoBehaviour
{
    public int steampunk; //-1 = locked, 0 = begin, 1 = valve, 2 = turbine, 3 = ende
    public int steampunk_furnace; //0 = begin, 1 = solved
    public int steampunk_valve; //0 = begin, 1 = turned
    public int steampunk_lever; //0 = begin, 1&2 = gears, 3 = electric
    public int gear_11_state, gear_2_state; //0=default, 1=weggeschleudert, 2=aufgenommen, 3=ende
    public int keycards; //0=default

#pragma warning disable CS0108
    public GameObject camera, player, lever, gears, keypad, valve3, valveMain, entrance;
#pragma warning restore CS0108

    public void resetSteampunk() { steampunk = -1; steampunk_furnace = 0; steampunk_valve = 0; steampunk_lever = 0; gear_11_state = 0; gear_2_state = 0; keycards = 0; }

    public void loadFormData(float[] data)
    {
        steampunk = (int) data[5];
        steampunk_furnace = (int)data[6];
        steampunk_valve = (int)data[7];
        steampunk_lever = (int)data[8];
        gear_11_state = (int)data[9];
        gear_2_state = (int)data[10];
        keycards = (int)data[11];

    }

    private void Start()
    {
        PlayerData data = SaveSystem.loadProgress();
        if (data != null)
        {
            transform.position = new Vector3(data.savedProgress[0], data.savedProgress[1], data.savedProgress[2]);
            player.transform.rotation = Quaternion.Euler(0f, data.savedProgress[3], 0f);
            camera.transform.rotation = Quaternion.Euler(data.savedProgress[4], 0f, 0f);
            loadFormData(data.savedProgress);
            entrance.GetComponent<unlockSteampunk>().loadDoors();
            valveMain.GetComponent<SpinValveMain>().loadValveMain();
            lever.GetComponent<Lever>().loadLever();
            gears.GetComponent<turnGears>().updateGears();
            keypad.GetComponent<KeypadSteampunk>().loadKeypad();
            valve3.GetComponent<spinValve3>().loadValve3();
        }
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(saveGame());
        }*/
        if (Input.GetKeyDown(KeyCode.F1))
        {
            string path = Application.persistentDataPath + "/player.dat";
            File.Delete(path);
        }
    }

    private IEnumerator saveGame()
    {
        float[] data = { player.transform.position.x, player.transform.position.y, player.transform.position.z, player.transform.localEulerAngles.y, camera.transform.localEulerAngles.x, steampunk, steampunk_furnace, steampunk_valve, steampunk_lever, gear_11_state, gear_2_state, keycards };
                      // 0-2 = pos,                                                                             3 = playerRotY,                      4 = camRotX,                 5 = steampunk, 6 = steampunk_furnace, 7 = steampunk_valve, 8 = steampunk_lever

        SaveSystem.SavePlayer(data);
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Scenes/Menu", LoadSceneMode.Single);
        yield return null;
    }

    private IEnumerator loadSaved()
    {

        string path = Application.persistentDataPath + "/player.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            player.transform.position = new Vector3(data.savedProgress[0], data.savedProgress[1], data.savedProgress[2]);
            player.transform.localRotation = Quaternion.Euler(0f, data.savedProgress[3], 0f);
            camera.transform.localRotation = Quaternion.Euler(data.savedProgress[4], 0f, 0f);
            loadFormData(data.savedProgress);
            stream.Close();

            yield return null;
        }
    }
}