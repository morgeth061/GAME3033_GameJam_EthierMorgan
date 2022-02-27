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
    private AudioSource jumpSFX;

    void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        jumpSFX = gameObject.GetComponent<AudioSource>();
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
            jumpSFX.Play();
            rigidBody.AddForce(new Vector3(0.0f, 250.0f, 0.0f));
            animator.SetBool("IsGrounded", false);
            animator.SetTrigger("Jump");
            isGrounded = false;
        }
    }

    public void OnPause(InputValue value)
    {
        gameController.GetComponent<GameController>().Pause();
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (playerMovement * Time.deltaTime), transform.position.y, transform.position.z);

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

        if (other.CompareTag("DeathPlane"))
        {
            gameController.GetComponent<GameController>().ShowEndUI(false);
        }
    }
}
