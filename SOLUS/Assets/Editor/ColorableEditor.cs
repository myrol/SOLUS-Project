using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Colorable))]
public class ColorableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Colorable script = (Colorable)target;
        
        if(GUILayout.Button("Apply Color"))
        {
            script.applyColor();
        }
    }
}
