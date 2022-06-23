using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class electrify : MonoBehaviour
{
    public GameObject electric_arc, seekers, steampunk_keycard;

    private void Start()
    {
        electric_arc.SetActive(false);
    }

    public IEnumerator Explode()
    {
        electric_arc.SetActive(true);

        //play Sound
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2.25f);

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