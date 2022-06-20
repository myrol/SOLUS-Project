using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
#pragma warning disable CS0108
    public GameObject cameraShaking;
#pragma warning restore CS0108
    public IEnumerator Shake (float duration, float power)
    {
        Vector3 originalPos = cameraShaking.transform.localPosition;

        float elapsed = 0.0f;
        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * power;
            float y = Random.Range(-1f, 1f) * power;

            cameraShaking.transform.localPosition = new Vector3(originalPos.x +x, originalPos.y+ y, originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraShaking.transform.localPosition = originalPos;
        yield return null;
    }
}
