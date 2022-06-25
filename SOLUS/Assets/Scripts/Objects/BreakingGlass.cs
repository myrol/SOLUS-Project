using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGlass : MonoBehaviour
{
    [SerializeField] private GameObject nonBrokenGlass;
    [SerializeField] private GameObject glassObj;
    [SerializeField] private float breakingForce = 500f;
#pragma warning disable CS0108
    [SerializeField] private AudioSource audio;
#pragma warning restore CS0108
    private bool alreadyActivated = false;

    private void Awake()
    {
        nonBrokenGlass.SetActive(true);
        glassObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (alreadyActivated || other.gameObject.layer != 8) return; // Carryable
        alreadyActivated = true;

        nonBrokenGlass.SetActive(false);
        glassObj.SetActive(true);

        Transform glass = glassObj.transform;

        for (int i = 0; i < glass.childCount; i++)
        {
            Transform child = glass.GetChild(i);
            Rigidbody rb = child.GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(other.gameObject.GetComponent<Rigidbody>().velocity * 50);
        }

        SoundManager.Instance.playSFX(audio);

        StartCoroutine(destroy());
    }

    private IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        glassObj.SetActive(false);
        Destroy(gameObject);
        yield return null;
    }
}
