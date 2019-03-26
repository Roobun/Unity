using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.1f;
    public float rotationRate = 180;
    public Joystick joystick;
    public JoybuttonController joybutton;

    private Rigidbody rb;
    private Animator anim;
    private GameController gameController;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        joystick = FindObjectOfType<Joystick>();
        joybutton = FindObjectOfType<JoybuttonController>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gameController.AddScore();
        }

        if (other.CompareTag("EndingPoint"))
        {
            Destroy(other.gameObject);
            gameController.Win();
        }
    }

    private void FixedUpdate()
    {
        if (!gameController.stopPlayer)
        {
            float moveAxis = joystick.Vertical;
            float turnAxis = joystick.Horizontal;

            ApplyInput(moveAxis, turnAxis);
        }
        else 
        {
            anim.SetInteger("Speed", 0);
        }
    }

    private void ApplyInput(float moveInput, float turnInput)
    {
        Move(moveInput);
        Turn(turnInput);
    }

    private void Move(float input)
    {
        bool isRunning = joybutton.pressed;
        transform.Translate(Vector3.forward * input * moveSpeed * (isRunning ? 1.5f : 1));

        anim.SetInteger("Speed", SpeedValue(input, isRunning));
    }

    private int SpeedValue(float input, bool isRunning)
    {
        if (isRunning)
        {
            return 2;
        }
        else if (input != 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    private void Turn(float input)
    {
        transform.Rotate(0, input * rotationRate * Time.deltaTime, 0);
    }
}
