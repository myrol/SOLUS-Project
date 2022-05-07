using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private float mouseSensitivity = 300f;
    public Transform playerBody;
    private float xRotation = 0f;
    public Camera cam;

    Vector2 mouse;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;   //Locked die Maus am Anfang des Spiels
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //Clamped die Vertikale Rotation 
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //Transformiert die Rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}