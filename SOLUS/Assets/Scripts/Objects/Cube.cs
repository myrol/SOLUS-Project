using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Carryable
{
    public MeshRenderer meshRenderer;

    private const string MATERIAL_PATH = "Materials/Room1/Button/";

    [SerializeField][Range(0,3)]
    public byte color;

    // Update is called once per frame
    private void Start()
    {
        changeColor(color);
    }
    private void changeColor(byte _color)
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