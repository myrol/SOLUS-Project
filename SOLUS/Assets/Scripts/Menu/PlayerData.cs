using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float[] savedProgress; // 0-2 = pos, 3 = playerRotY, 4 = camRotX, 5 = steampunk, 6 = steampunk_furnace, 7 = steampunk_valve, 8 = steampunk_lever

    public PlayerData (float[] nowProgress)
    {
        savedProgress = nowProgress;
    }
}