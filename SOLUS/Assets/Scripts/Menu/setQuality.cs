using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setQuality : MonoBehaviour
{
    // Start is called before the first frame update
    public void setQ (int Qindex)
    {
        QualitySettings.SetQualityLevel(Qindex);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}
