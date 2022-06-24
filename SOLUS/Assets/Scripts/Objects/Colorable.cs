using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorable : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    [Range(0, 3)] public byte color;

    private const string MATERIAL_PATH = "Materials/Room1/Cubes/";

    private void Awake()
    {
        applyColor();
    }

    public void applyColor()
    {
        switch (color)
        {
            case 0:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "black");
                break;
            case 1:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "blue");
                break;
            case 2:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "green");
                break;
            case 3:
                meshRenderer.material = Resources.Load<Material>(MATERIAL_PATH + "red");
                break;
        }
    }
}
