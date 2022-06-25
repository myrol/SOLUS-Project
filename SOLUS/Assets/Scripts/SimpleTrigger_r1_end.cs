using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger_r1_end : MonoBehaviour
{
    [SerializeField] private UnityEvent eve;
    [SerializeField] private string tag;
    public GameObject end_announcer, end_announcer2;
    bool done = false;

    private void Start()
    {
        if (tag == "") tag = "Player";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tag && !done)
        {
            StartCoroutine(r1_end());
        }
    }

    private IEnumerator r1_end()
    {
        end_announcer.SetActive(true);
        yield return new WaitForSeconds(15);
        eve.Invoke();
        yield return new WaitForSeconds(20);
        end_announcer2.SetActive(true);
        end_announcer2.transform.position = GameObject.Find("Player").transform.position;
        Destroy(gameObject);
        yield return null;
    }
}