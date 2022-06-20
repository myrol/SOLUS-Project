using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(InstantiateArray))]
public class MovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Movement script = (Movement)target;
        if (GUILayout.Button("Restart Position"))
        {
        }
    }
}