using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSparks : MonoBehaviour
{
    GameObject Pos_transmission1, Pos_transmission2, Pos_transmission3, Pos_transmission4;
    Vector3 originalSparkPos;

    private void Start()
    {
        Pos_transmission1 = GameObject.Find("Pos_transmission1");
        Pos_transmission2 = GameObject.Find("Pos_transmission2");
        Pos_transmission3 = GameObject.Find("Pos_transmission3");
        Pos_transmission4 = GameObject.Find("Pos_transmission4");
        originalSparkPos = Pos_transmission1.transform.localPosition;
    }

    public IEnumerator startMovement()
    {
        Pos_transmission2.transform.localPosition = originalSparkPos;
        Pos_transmission3.transform.localPosition = originalSparkPos;
        Pos_transmission4.transform.localPosition = originalSparkPos;
        while (true)
        {
            float z1 = Random.Range(0.1f, 2f);
            float z2 = Random.Range(0.1f, 2f);
            float z3 = Random.Range(0.1f, 2f);

            Pos_transmission2.transform.localPosition += new Vector3(0, 0, -z1);
            Pos_transmission3.transform.localPosition += new Vector3(0, 0, -z2);
            Pos_transmission4.transform.localPosition += new Vector3(0, 0, -z3);

            if (Pos_transmission2.transform.localPosition.z <= 23f)
            {
                Pos_transmission2.transform.localPosition = originalSparkPos;
            }
            if (Pos_transmission3.transform.localPosition.z <= 23f)
            {
                Pos_transmission3.transform.localPosition = originalSparkPos;
            }
            if (Pos_transmission4.transform.localPosition.z <= 23f)
            {
                Pos_transmission4.transform.localPosition = originalSparkPos;
            }
            yield return null;
        }
    }
}
