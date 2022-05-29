using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class disableOnStart : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("PlayerCapsule");
        player.SetActive(false);
    }
    void ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.

        //After we have waited 5 seconds print the time again.
        player.SetActive(true);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
