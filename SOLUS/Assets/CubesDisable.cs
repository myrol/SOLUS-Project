using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubesDisable : MonoBehaviour
{
    [SerializeField] private UnityEvent eve;
    [SerializeField] private string tag;

    private void Start()
    {
        if (tag == "") tag = "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag)
        {
            GameObject.Find("BlackCube(Clone)").SetActive(false);
            GameObject.Find("GreenCube(Clone)").SetActive(false);
            GameObject.Find("RedCube(Clone)").SetActive(false);
            GameObject.Find("BlueCube(Clone)").SetActive(false);
            Destroy(gameObject);
        }
    }
}
