using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnGears : MonoBehaviour
{
    private GameObject gear11;
    private GameObject gear2;
    private GameObject gear8;
    private GameObject gear1;

    public float speed;
    
    /*private void Update()
    {
        gear11 = GameObject.Find("gear11");
        gear2 = GameObject.Find("gear2");
        gear8 = GameObject.Find("gear8");
        gear1 = GameObject.Find("gear1");

        float elapsed = 0.0f;
        speed = 0.01f;
        while (elapsed < 5f)
        {
            elapsed += Time.deltaTime;
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 0.0036779f, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 0.0036779f * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 0.0036779f * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 0.0036779f * (32f / 12f)  *  (28f / 12f), Space.Self);
            elapsed += 0.01f;
        }
    }*/

    public IEnumerator Explode()
    {
        gear11 = GameObject.Find("gear11");
        gear2 = GameObject.Find("gear2");
        gear8 = GameObject.Find("gear8");
        gear1 = GameObject.Find("gear1");

        float elapsed = 0.0f;
        while (elapsed < 5f)
        {
            elapsed += Time.deltaTime;
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            yield return null;
        }
        gear11.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        gear2.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        gear8.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        gear1.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
        yield return null;
    }
}
