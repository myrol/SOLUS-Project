using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variablen für Bewegung
    public CharacterController controller;
    private float speed = 0f;
    private float maxSpeed;
    private float acceleration = 0.15f;
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
    private float crouchingSpeed = 3f;
    private float standingSpeed = 7f;
    private float crouchHeight = 1f;
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

        if (x != 0 || z != 0)
        {
            speed += acceleration;
        } else if (x == 0 && z == 0)
        {
            speed -= acceleration * 10f;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        Debug.Log(speed);

        Vector3 move = (transform.right * x + transform.forward * z).normalized;
        //Spieler Bewegung
        if (!isJumping)
        {
            controller.Move(move * speed * Time.deltaTime);
        } else
        {
            velocity += (move * speed * Time.deltaTime * jumpTrajectoryControl * 3f);
            //controller.Move(move * speed * Time.deltaTime * jumpTrajectoryControl);
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
            maxSpeed = crouchingSpeed;
        }
        else
        {
            controller.height = standingHeight;
            maxSpeed = standingSpeed;
        }

        //Spieler Bewegung in der Luft
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}