using System.Collections;
using UnityEngine;

public class turnGears : MonoBehaviour
{
    private GameObject gear11; // -> 32
    private GameObject gear2;  // -> 12
    private GameObject gear8;  // -> 28
    private GameObject gear1;  // -> 12
    private GameObject tesla;

    public float speed;

    private void Start()
    {
        gear11 = GameObject.Find("gear11");
        gear2 = GameObject.Find("gear2");
        gear8 = GameObject.Find("gear8");
        gear1 = GameObject.Find("gear1");
        tesla = GameObject.Find("tesla");
    }

    public IEnumerator turner()
    {

        float elapsed = 0.0f;
        while (elapsed < 5.0f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            yield return null;
        }
        while (elapsed < 10.0f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 5.0f, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 5.0f * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * 5.0f * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * 5.0f * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(tesla.GetComponent<electrify>().Explode());
        while (elapsed > 0f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed -= Time.deltaTime * 2f;
            yield return null;
        }
        yield return null;
    }

    public IEnumerator Explode()
    {

        float elapsed = 0.0f;
        while (elapsed < 5f)
        {
            gear11.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed, Space.Self);
            gear2.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear8.transform.Rotate(0.0f, 0.0f, -1.0f * speed * elapsed * (32f / 12f), Space.Self);
            gear1.transform.Rotate(0.0f, 0.0f, 1.0f * speed * elapsed * (32f / 12f) * (28f / 12f), Space.Self);
            elapsed += Time.deltaTime;
            yield return null;
        }
        gear11.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear2.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear8.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        gear1.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        //wegschleudern
        elapsed = 0.0f;
        while (elapsed < 0.5f)
        {
            gear11.transform.localPosition = gear11.transform.localPosition + new Vector3(0.1f, 0.05f, -0.02f);
            gear2.transform.localPosition = gear2.transform.localPosition + new Vector3(-0.1f, 0.05f, -0.01f);
            elapsed += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.1f);
        gear11.transform.localRotation = Quaternion.Euler(82.2f, 90f, 90f);
        gear11.transform.localPosition = new Vector3(71.641f, 5.233f, 34.754f);
        gear2.transform.localRotation = Quaternion.Euler(-45f, 45f, 0f);
        gear2.transform.localPosition = new Vector3(-23.007f, 0.439f, 33.313f);
        yield return null;
    }
}