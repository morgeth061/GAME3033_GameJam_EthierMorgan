using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject gameController;

    private float playerMovement;
    private bool isGrounded = true;
    private Rigidbody rigidBody;
    private Animator animator;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void OnMovement(InputValue value)
    {
        if (gameController.GetComponent<GameController>().canMove)
            playerMovement = value.Get<float>();
    }

    public void OnJump(InputValue value)
    {
        if (gameController.GetComponent<GameController>().canMove && isGrounded)
        {
            rigidBody.AddForce(new Vector3(0.0f, 250.0f, 0.0f));
            animator.SetBool("IsGrounded", false);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (playerMovement * 0.001f), transform.position.y, transform.position.z);

        if (rigidBody.velocity.y < 0)
        {
            animator.SetBool("IsFalling", true);
        }
        else
        {
            animator.SetBool("IsFalling", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            animator.SetTrigger("Hit");
            collision.gameObject.SetActive(false);
            gameController.GetComponent<GameController>().GameLoss();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsGrounded", true);
        }
    }
}
