using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variablen für Bewegung
    public CharacterController controller;
    private float speed = 7f;
    Vector3 velocity;

    //Variablen fürs Fallen
    private float gravity = -9.81f;
    public Transform groundCheck;
    private float distance = 0.1f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Variablen fürs Springen
    Vector3 moveAtTakeoff;
    private float jumpTrajectoryControl = .5f; // % inwiefern der Spieler kontroller in der Luft hat
    private float jumpThrust = .8f; // % vom movement speed
    private float jumpheight = 0.5f;
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
            isJumping = false;
            velocity = new Vector3(0f, -2f, 0f);
            moveAtTakeoff = new Vector3(0f, 0f, 0f);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        //Spieler Bewegung
        if (!isJumping)
        {
            controller.Move(move * speed * Time.deltaTime);
        } else
        {
            //velocity += (move.normalized * speed * Time.deltaTime * jumpTrajectoryControl);
            controller.Move(move * speed * Time.deltaTime * jumpTrajectoryControl);
        }

        //Wenn Leertaste gedrückt wird, springt der Spieler
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
            moveAtTakeoff = move;
            velocity = new Vector3(0f, Mathf.Sqrt(jumpheight * (-2f) * gravity), 0f);
            velocity += moveAtTakeoff * speed * jumpThrust;
        }

        //Wenn LStrg gedrückt wird, duckt sich der Spieler
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchHeight;
            speed = 3f;
        }
        else
        {
            controller.height = standingHeight;
            speed = 7f;
        }

        Debug.Log(moveAtTakeoff.x + " " + moveAtTakeoff.y + " " + moveAtTakeoff.z);
        //Spieler Bewegung in der Luft
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}