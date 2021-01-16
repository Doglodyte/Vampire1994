using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    //Stats
    public float speed;
    public float speedRun = 16f;
    public float speedBase = 8f;
    public float jumpHeight = 3f;

    //Gravity Settings
    float gravity;
    public float gravityBase = -10f;
    [SerializeField] float gravityMultFall = 2f;
    [SerializeField] float gravityMultLowJump = 1f;

    public CharacterController controller;

    public Transform groundCheck;
    [SerializeField] float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    //Mouse Stuff
    public float mouseSensitivity = 750f;

    public Transform playerBody;
    public Camera cam;

    float xRotation = 0f;

    private void Start()
    {
        gravity = gravityBase;
        speed = speedBase;

        groundCheck = GameObject.Find("Player").transform;
        controller = GetComponent<CharacterController>();
        playerBody = GetComponent<Transform>();

        //Mouse Stuff
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
    }

    void Update()
    {
        //Check if touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            gravity = gravityBase;
        }


        //Get WASD Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Apply WASD Input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        //Sprinting
        if (Input.GetKeyDown("left shift") && speed == speedBase)
        {
            speed = speedRun;
        }
        else if (Input.GetKeyDown("left shift") && speed == speedRun)
        {
            speed = speedBase;
        }



        //Jumping
        if (Input.GetKeyDown("space") && isGrounded)
        {
            gravity = gravityBase * gravityMultLowJump;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (Input.GetKeyUp("space"))
        {
            gravity = gravityBase * gravityMultFall;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        //Mouse Stuff
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void MoveAndSprint()
    {
        //Get WASD Input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Apply WASD Input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);


        //Sprinting
        if (Input.GetKeyDown("left shift") && speed == speedBase)
        {
            speed = speedRun;
        }
        else if (Input.GetKeyDown("left shift") && speed == speedRun)
        {
            speed = speedBase;
        }
    }

    void Jumping()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            gravity = gravityBase * gravityMultLowJump;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        else if (Input.GetKeyUp("space"))
        {
            gravity = gravityBase * gravityMultFall;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
