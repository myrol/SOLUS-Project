using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer buttonMesh;

    private const string MATERIAL_PATH = "Materials/Room1/Button/";

    private List<Collider> cubesOnButton;

    [SerializeField]
    [Range(0, 3)]
    private byte color = 0;
    
    public UnityEvent buttonPressed;
    public UnityEvent buttonUnpressed;

    private void Start()
    {
        changeColor(color);
        cubesOnButton = new List<Collider>();
    }

    private void FixedUpdate()
    {
        changeColor(color);
    }

    private void changeColor(byte _color)
    {
        switch (color)
        {
            case 0:
                buttonMesh.material = Resources.Load<Material>(MATERIAL_PATH + "black");
                break;
            case 1:
                buttonMesh.material = Resources.Load<Material>(MATERIAL_PATH + "blue");
                break;
            case 2:
                buttonMesh.material = Resources.Load<Material>(MATERIAL_PATH + "green");
                break;
            case 3:
                buttonMesh.material = Resources.Load<Material>(MATERIAL_PATH + "red");
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Colorable c = other.gameObject.GetComponent<Colorable>();
        if (c == null && other.tag != "Player") return;

        // If it's the player or the color of the cube matches
        if(other.tag == "Player" || c.color == GameAssets.COLOR_BLACK || c.color == color )
        {
            cubesOnButton.Add(other);

            if (cubesOnButton.Count == 1)
            {
                buttonPressed.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!cubesOnButton.Contains(other)) return;

        if (other.tag == "Player" ||
            other.gameObject.tag == "Cube")
        {
            cubesOnButton.Remove(other);

            if (cubesOnButton.Count == 0)
            {
                buttonUnpressed.Invoke();
            }
        }
    }
}