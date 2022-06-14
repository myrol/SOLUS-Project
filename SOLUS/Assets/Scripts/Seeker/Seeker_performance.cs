using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Seeker_performance : MonoBehaviour
{
    GameObject Seekers;
    GameObject Tuto;
    bool done = false;
    void Update()
    {
        if (QualitySettings.GetQualityLevel() == 0)
        {
            Seekers = GameObject.Find("Seekers");
            Seekers.SetActive(false);
        }
        else if(!done)
        {
            Tuto = GameObject.Find("Tutorial");
            GameObject player = GameObject.Find("PlayerCapsule");
            player.transform.position = new Vector3(60.0f, 60.0f, 60.0f);
            Tuto.SetActive(false);
            done = true;
        }
    }
}
