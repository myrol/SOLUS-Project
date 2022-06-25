using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger_r1_end : MonoBehaviour
{
    [SerializeField] private UnityEvent eve;
    public GameObject end_announcer;
    
    private bool done = false;

    private void Start()
    {
        if (tag == "") tag = "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        Colorable cubeColor = other.gameObject.GetComponent<Colorable>();

        if (cubeColor == null || other.gameObject.tag != "Cube") return;

        if ( !done &&  (cubeColor.color == GameAssets.COLOR_BLACK || 
                        cubeColor.color == GameAssets.COLOR_RED) )
        {
            StartCoroutine(r1_end());
        }
    }

    private IEnumerator r1_end()
    {
        end_announcer.GetComponent<DialogueTrigger>().remotePlay();
        eve.Invoke();
        Destroy(gameObject);
        yield return null;
    }
}