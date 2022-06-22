using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StoryHolder : MonoBehaviour
{
    public int steampunk; //0 = begin, 1 = valve, 2 = turbine
    public int steampunk_furnace; //0 = begin, 1 = solved
    public int steampunk_valve; //0 = begin, 1 = turned
    public int steampunk_lever; //0 = begin, 1&2 = gears, 3 = electric

#pragma warning disable CS0108
    public GameObject camera, player;
#pragma warning restore CS0108

    public void resetSteampunk() { steampunk = 0; steampunk_furnace = 0; steampunk_valve = 0; steampunk_lever = 0; }
    public void addSteampunk() { steampunk += 1; }
    public void addSteampunkFurnace() { steampunk_furnace += 1; }
    public void addSteampunkValve() { steampunk_valve += 1; }
    public void addSteampunkLever() { steampunk_lever += 1; }
    public int getSteampunk() { return steampunk; }
    public int getSteampunkFurnace() { return steampunk_furnace; }
    public int getSteampunkValve() { return steampunk_valve; }
    public int getSteampunkLever() { return steampunk_lever; }

    public void loadFormData(float[] data)
    {
        steampunk = (int) data[5];
        steampunk_furnace = (int)data[6];
        steampunk_valve = (int)data[7];
        steampunk_lever = (int)data[8];
    }

    private void Start()
    {
        PlayerData data = SaveSystem.loadProgress();
        if (data != null)
        {
            /*StartCoroutine(loadSaved()); */

            transform.position = new Vector3(data.savedProgress[0], data.savedProgress[1], data.savedProgress[2]);
            player.transform.rotation = Quaternion.Euler(0f, data.savedProgress[3], 0f);
            camera.transform.rotation = Quaternion.Euler(data.savedProgress[4], 0f, 0f);
            loadFormData(data.savedProgress);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(saveGame());
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            string path = Application.persistentDataPath + "/player.dat";
            File.Delete(path);
        }
    }

    private IEnumerator saveGame()
    {
        float[] data = { player.transform.position.x, player.transform.position.y, player.transform.position.z, player.transform.localEulerAngles.y, camera.transform.localEulerAngles.x, steampunk, steampunk_furnace, steampunk_valve, steampunk_lever };
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