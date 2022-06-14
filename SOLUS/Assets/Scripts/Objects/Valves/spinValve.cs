using System.Collections;
using UnityEngine;

public class spinValve : MonoBehaviour
{

    public AudioClip turnAudio;
    public AudioSource source;

    public void turn()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(turner());
    }

    public IEnumerator turner()
    {
        if (transform.localEulerAngles.y == 0)
        {
            float elapsed = 0.0f;
            source.PlayOneShot(turnAudio, 1f);

            yield return new WaitForSeconds(.3f);
            while (elapsed < 180f)
            {
                transform.Rotate(0.0f, -1f, 0.0f, Space.Self);
                elapsed += 0.12f;
                yield return null;
            }
        }
    }
}