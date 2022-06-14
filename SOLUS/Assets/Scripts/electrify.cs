using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrify : MonoBehaviour
{
    private GameObject electric_arc;
    private GameObject seekers;

    private void Start()
    {
        electric_arc = GameObject.Find("electric_arc");
        seekers = GameObject.Find("Seekers");
        electric_arc.SetActive(false);
    }

    public IEnumerator Explode()
    {
        electric_arc.SetActive(true);

        //play Sound
        yield return new WaitForSeconds(2);

        electric_arc.SetActive(false);

        yield return new WaitForSeconds(4);

        //play announcer and move laby (set day?)
        float elapsed = 0.0f;
        while (elapsed < 4.0f)
        {
            elapsed += Time.deltaTime;
            seekers.transform.position += Vector3.down * Time.deltaTime / 4;
            yield return null;
        }
        seekers.SetActive(false);

        yield return null;
    }
}