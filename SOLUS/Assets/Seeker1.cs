using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Seeker1 : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        VisualEffect v = GetComponent<VisualEffect>();
        v.playRate = 0.25f;
    }
    void Update()
    {
    }
}
