using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Photon.MonoBehaviour
{
    public PhotonView photonView;
    private Vector3 movement;
    public CharacterController characterController;
    public float speed = 12;
    public float gravity = -20;
    public LayerMask layerMask;
    public Transform check;
    private bool isGrounded;
    Vector3 velocity;
    public float jump = 2;
    public float runSpeed = 7;
    //public AudioClip clip;
    public GameObject playerCamera;

    private bool isPlaying;

    private void Awake()
    {
        if (GetComponent<PhotonView>().isMine)
        {
            playerCamera.SetActive(true);
        }
    }
    void Update()
    {
        if (GetComponent<PhotonView>().isMine)
        {
            Gravity();
            PlayerMovement();
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(check.position, 0.4f, layerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");

        movement = transform.right * movement.x + transform.forward * movement.z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            characterController.Move(movement * runSpeed * Time.deltaTime);
        }
        else
        {
            characterController.Move(movement * speed * Time.deltaTime);
        }
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2 * gravity);
        }
    }
}
