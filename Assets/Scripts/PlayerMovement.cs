using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5f;
    public float jump = 2f;
    public Transform groundCheck;
    public float groundDist;
    public LayerMask groundLayer;

    private float xDir;
    private float zDir;
    private float yDir;
    private Vector3 moveDir;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDist, groundLayer);
        if (isGrounded && yDir < 0)
            yDir = -2f;

        xDir = Input.GetAxis("Horizontal");
        zDir = Input.GetAxis("Vertical");
        yDir += Physics.gravity.y * Time.deltaTime;

        moveDir = transform.right * xDir * speed + transform.forward * zDir * speed + transform.up * yDir;
        characterController.Move(moveDir * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
            yDir = Mathf.Sqrt(jump * -1f * Physics.gravity.y);
    }
}
