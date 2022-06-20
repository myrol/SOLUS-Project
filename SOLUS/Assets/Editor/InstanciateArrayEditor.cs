using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InstantiateArray))]
public class InstanciateArrayEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        InstantiateArray script = (InstantiateArray) target;
        if (GUILayout.Button("Build Array"))
        {
            script.instantiate();
        }

        if (GUILayout.Button("Destroy"))
        {
            script.destroy();
        }

        if (GUILayout.Button("Update"))
        {
            script.destroy();
            script.instantiate();
        }
    }
}
