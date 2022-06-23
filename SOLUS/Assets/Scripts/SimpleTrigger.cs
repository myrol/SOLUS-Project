using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
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
            eve.Invoke();
            Destroy(gameObject);
        }
    }
}
