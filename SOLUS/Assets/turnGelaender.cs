using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnGelaender : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(gameObject.transform.eulerAngles.x);
    }
    public void turn()
    {
        StartCoroutine(turner());
    }

    private IEnumerator turner()
    {
        gameObject.transform.Rotate(-3f, 0.0f, 0.0f, Space.Self);
        while (gameObject.transform.eulerAngles.x > 280)
        {
            gameObject.transform.Rotate(-3f, 0.0f, 0.0f, Space.Self);
            yield return null;
        }
        yield return null;
    }
}
