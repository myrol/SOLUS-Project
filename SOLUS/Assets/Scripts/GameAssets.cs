using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets Instance = new GameAssets();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public const byte COLOR_BLACK   = 0;
    public const byte COLOR_BLUE    = 1;
    public const byte COLOR_GREEN   = 2;
    public const byte COLOR_RED     = 3;

    public Transform LOCATION_TUTORIAL;
    public Transform LOCATION_SPAWN;
    public Transform LOCATION_ROOM1;
    public Transform LOCATION_ROOM2;
    public Transform LOCATION_ROOM3;
}