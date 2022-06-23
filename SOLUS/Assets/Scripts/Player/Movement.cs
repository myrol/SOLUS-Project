using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Variablen für Bewegung
    public CharacterController controller;
    private bool moving = false;
    private bool footstepsPlaying = false;
    private float speed;
    private Vector3 velocity;
    private Vector2 currentInputVector;

    //Variablen fürs Fallen
    private float gravity = -11f;
    public Transform groundCheck;
    private float x_dist = 0.375f;
    private float y_dist = 0.05f;
    public LayerMask groundMask;
    private bool isGrounded;

    //Variablen fürs Springen
    private float jumpTrajectoryControl = 2f; // % inwiefern der Spieler kontroller in der Luft hat
    private float jumpThrust = .8f; // % vom movement speed
    private float jumpheight = 0.65f;

    //Variablen für Ducken
    [SerializeField] private float crouchingSpeed = 2.5f;
    [SerializeField] private float standingSpeed = 4f;
    private Vector3 groundCheckPositionChange = new Vector3(0f, 0.5f, 0f);
    private float crouchHeight = 1f;
    private float standingHeight = 2f;

    private void Start()
    {
        speed = standingSpeed;
    }

    void Update()
    {
        //Checkt ob der Spieler auf dem Boden ist
        //isGrounded = Physics.CheckSphere(groundCheck.position, distance, groundMask);
        isGrounded = Physics.CheckBox(groundCheck.position + new Vector3(0, y_dist/2, 0), new Vector3(x_dist, y_dist, x_dist), Quaternion.identity , groundMask);
        Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(x_dist, 0, 0));
        Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(-x_dist, 0, 0));
        Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, 0, x_dist));
        Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, 0, -x_dist));
        Debug.DrawLine(groundCheck.position, groundCheck.position + new Vector3(0, -y_dist, 0));

        //Wenn Spieler auf dem Boden, wird die Fallgeschwindigkeit reduziert
        if (isGrounded && velocity.y < 0)
        {
            velocity = new Vector3(0f, -5f, 0f);
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        currentInputVector = new Vector2(x, z);

        if (currentInputVector.magnitude > 0) moving = true;
        else moving = false;

        if (isGrounded && moving && !footstepsPlaying) StartCoroutine(playFootsteps()); // AUDIO

        Vector3 move = (transform.right * currentInputVector.x + transform.forward * currentInputVector.y).normalized;
        //Spieler Bewegung
        if (isGrounded) {
            controller.Move(move * speed * Time.deltaTime);
        } else {
            float hor_speed = new Vector3(velocity.x, 0, velocity.z).magnitude;
            if (hor_speed < 6f)
            {
                velocity += ((1/(hor_speed+0.85f)) * 2.25f) * (move * speed * Time.deltaTime * jumpTrajectoryControl * 3f);
            }
            //controller.Move(move * speed * Time.deltaTime * jumpTrajectoryControl);
        }

        //Wenn Leertaste gedrückt wird, springt der Spieler
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity = new Vector3(0f, Mathf.Sqrt(jumpheight * (-2f) * gravity), 0f);
            velocity += move * speed * jumpThrust;

            StartCoroutine(playLiftOff()); // AUDIO
        }

        //Wenn LStrg gedrückt wird, duckt sich der Spieler
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            controller.height = crouchHeight;
            groundCheck.position += groundCheckPositionChange;
            speed = crouchingSpeed;
        } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
            controller.height = standingHeight;
            groundCheck.position -= groundCheckPositionChange;
            speed = standingSpeed;
        }

        //Spieler Bewegung in der Luft
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator playFootsteps()
    {
        footstepsPlaying = true;

        SoundManager.Instance.playRandom(SoundManager.Instance.player_footsteps);
        yield return new WaitForSeconds(.4f);

        footstepsPlaying = false;
    }

    private IEnumerator playLiftOff()
    {
        SoundManager.Instance.playRandom(SoundManager.Instance.player_liftOff);

        yield return null;
    }
}