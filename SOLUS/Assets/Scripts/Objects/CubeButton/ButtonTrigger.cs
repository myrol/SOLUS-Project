using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonTrigger : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer buttonMesh;

    private const byte BLACK = 0;
    private const byte BLUE = 1;
    private const byte GREEN = 2;
    private const byte RED = 3;

    private const string MATERIAL_PATH = "Materials/Room1/Button/";

    [SerializeField]
    [Range(0, 3)]
    private byte color = 0;
    
    public LayerMask interactablesLayer;
    public UnityEvent buttonPressed;
    public UnityEvent buttonUnpressed;

    private void Start()
    {
        changeColor(color);
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
        Cube c = other.gameObject.GetComponent<Cube>();
        if (c == null && other.tag != "Player") return;

        // If it's the player or the color of the cube matches
        if(other.tag == "Player" || c.color == BLACK || c.color == color )
        {
            buttonPressed.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" ||
            other.gameObject.layer == LayerMask.NameToLayer("Interactable"))
        {
            buttonUnpressed.Invoke();
        }
    }
}