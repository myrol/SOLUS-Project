using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance;

    [SerializeField] private bool debug = false;

    [SerializeField] private List<GameObject> initLoad, initDeload;

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

    private void Start()
    {
        if (debug) return;

        deload(initDeload);
        load(initLoad);
    }

    public void load(List<GameObject> locations)
    {
        foreach (GameObject location in locations)
        {
            location.SetActive(true);
        }
    }

    public void deload(List<GameObject> locations)
    {
        foreach (GameObject location in locations)
        {
            location.SetActive(false);
        }
    }
}
