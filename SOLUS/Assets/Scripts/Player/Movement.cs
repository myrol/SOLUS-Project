using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variablen f�r Bewegung
    public CharacterController controller;
    private float speed = 7f;
    private Vector3 velocity;
    private Vector2 currentInputVector;
    private Vector2 smoothInputVelocity;
    private float smoothInputSpeed = .2f;

    //Variablen f�rs Fallen
    private float gravity = -11f;
    public Transform groundCheck;
    private float distance = 0.1f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Variablen f�rs Springen
    private float jumpTrajectoryControl = .5f; // % inwiefern der Spieler kontroller in der Luft hat
    private float jumpThrust = .8f; // % vom movement speed
    private float jumpheight = 0.5f;

    //Variablen f�r Ducken
    private float crouchingSpeed = 3f;
    private float standingSpeed = 7f;
    private float crouchHeight = 1f;
    private float standingHeight = 2f;

    void Update()
    {
        //Checkt ob der Spieler auf dem Boden ist
        isGrounded = Physics.CheckSphere(groundCheck.position, distance, groundMask);

        //Wenn Spieler auf dem Boden, wird die Fallgeschwindigkeit reduziert
        if (isGrounded && velocity.y < 0)
        {
            velocity = new Vector3(0f, -2f, 0f);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        currentInputVector = new Vector2(x, z);

        Vector3 move = (transform.right * currentInputVector.x + transform.forward * currentInputVector.y).normalized;
        //Spieler Bewegung
        if (isGrounded) {
            controller.Move(move * speed * Time.deltaTime);
        } else {
            //velocity += (move * speed * Time.deltaTime * jumpTrajectoryControl * 3f);
            controller.Move(move * speed * Time.deltaTime * jumpTrajectoryControl);
        }

        //Wenn Leertaste gedr�ckt wird, springt der Spieler
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = new Vector3(0f, Mathf.Sqrt(jumpheight * (-2f) * gravity), 0f);
            velocity += move * speed * jumpThrust;
        }

        //Wenn LStrg gedr�ckt wird, duckt sich der Spieler
        if (Input.GetKey(KeyCode.LeftControl)) {
            controller.height = crouchHeight;
            speed = crouchingSpeed;
        } else {
            controller.height = standingHeight;
            speed = standingSpeed;
        }

        //Spieler Bewegung in der Luft
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}