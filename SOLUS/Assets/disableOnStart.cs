using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disableOnStart : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Camera");
        player.SetActive(false);


        SceneManager.activeSceneChanged += ChangedActiveScene;

        // wait 1.5 seconds before change to Scene2
    }

    public delegate void Change();

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        player.SetActive(false);
        if (currentName == null)
        {
            // Scene1 has been removed
            currentName = "Replaced";
        }

        Debug.Log("Scenes: " + currentName + ", " + next.name);
    }

}
