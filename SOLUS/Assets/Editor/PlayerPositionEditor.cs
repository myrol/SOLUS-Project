using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerPosition))]
public class PlayerPositionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PlayerPosition script = (PlayerPosition)target;
        if (GUILayout.Button("Move to Tutorial"))
        {
            Debug.Log(script.LOCATION_TUTORIAL.position);
            script.gameObject.transform.position = script.LOCATION_TUTORIAL.position;
        }

        if (GUILayout.Button("Move to Spawn"))
        {
            script.gameObject.transform.position = script.LOCATION_SPAWN.position;
        }

        if (GUILayout.Button("Move to first room"))
        {
            script.gameObject.transform.position = script.LOCATION_ROOM1.position;
        }

        if (GUILayout.Button("Move to second room"))
        {
            script.gameObject.transform.position = script.LOCATION_ROOM2.position;
        }

        if (GUILayout.Button("Move to third room"))
        {
            script.gameObject.transform.position = script.LOCATION_ROOM3.position;
        }
    }
}