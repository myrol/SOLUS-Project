using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingGlass : MonoBehaviour
{
    [SerializeField] private GameObject nonBrokenGlass;
    [SerializeField] private GameObject glassObj;
    [SerializeField] private float breakingForce = 50f;
#pragma warning disable CS0108
    [SerializeField] private AudioSource audio;
#pragma warning restore CS0108

    private void Awake()
    {
        nonBrokenGlass.SetActive(true);
        glassObj.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8) return; // Carryable

        nonBrokenGlass.SetActive(false);
        glassObj.SetActive(true);

        Transform glass = glassObj.transform;

        for (int i = 0; i < glass.childCount; i++)
        {
            Transform child = glass.GetChild(i);
            Rigidbody rb = child.GetComponent<Rigidbody>();

            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(new Vector3(breakingForce, 0, 0));
        }

        SoundManager.Instance.playSFX(audio);

        Destroy(gameObject);
    }
}
