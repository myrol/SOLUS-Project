using System.Collections;
using UnityEngine;

public class spinValve : MonoBehaviour
{
    public void turn()
    {
        StartCoroutine(turner());
    }

    public IEnumerator turner()
    {
        if (transform.localEulerAngles.y == 0)
        {
            float elapsed = 0.0f;
            while (elapsed < 180f)
            {
                transform.Rotate(0.0f, -0.25f, 0.0f, Space.Self);
                elapsed += 0.25f;
                yield return null;
            }
        }
    }

    public void turnMain()
    {
        StartCoroutine(turnerMain());
    }

    public IEnumerator turnerMain()
    {
        if (transform.localEulerAngles.y == 0 && GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().getProgress() == 0)
        {
            GameObject.Find("Raum 0").GetComponent<SteampunkStoryHolder>().addProgress();
            float elapsed = 0.0f;
            while (elapsed < 180f)
            {
                transform.Rotate(0.0f, -0.25f, 0.0f, Space.Self);
                elapsed += 0.25f;
                yield return null;
            }
            //play sound
        }
    }
}
