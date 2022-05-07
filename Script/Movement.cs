using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variablen für Bewegung
    public CharacterController controller;
    private float speed = 7f;
    Vector3 velocity;
    //FVariablen fürs Fallen
    private float gravity = -9.81f;
    public Transform groundCheck;
    private float distance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    //Variablen fürs Springen
    private float jumpheight = 2f;
    private bool isJumping;
    //Variablen für Ducken
    private float crouchHeight = 1.3f;
    private float standingHeight = 2f;
    private bool isCrouching;


    void Update()
    {
        //Checkt ob der Spieler auf dem Boden ist
        isGrounded = Physics.CheckSphere(groundCheck.position, distance, groundMask);

        //Wenn Spieler auf dem Boden, wird die Fallgeschwindigkeit reduziert
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //Spieler Bewegung
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //Wenn Leertaste gedrückt wird, springt der Spieler
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (isJumping == true)
        {
            velocity.y = Mathf.Sqrt(jumpheight * (-2f) * gravity);
        }

        //Wenn LStrg gedrückt wird, duckt sich der Spieler
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded && isJumping == false)
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        if(isCrouching == true)
        {
            controller.height = crouchHeight;
            speed = 3f;
        }
        else
        {
            controller.height = standingHeight;
            speed = 7f;
        }

        //Spieler Bewegung in der Luft
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}