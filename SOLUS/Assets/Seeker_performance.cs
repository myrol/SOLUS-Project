using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Seeker_performance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualEffect v = GetComponent<VisualEffect>();
        v.playRate = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
