using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using TMPro;
using System.Linq;


public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    private Rigidbody2D player;
    private Vector2 moveInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (PauseController.IsGamePaused)
        {
            player.linearVelocity = Vector2.zero;
            animator.SetBool("isWalking", false);
            return;
        }
        
        player.linearVelocity = moveInput * moveSpeed;
        animator.SetBool("isWalking", player.linearVelocity.magnitude > 0);
    }

    public void Move(InputAction.CallbackContext context)
    {        
        if(context.canceled)
        {
            animator.SetBool("isWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    // if (collision.gameObject.CompareTag("Enemy"))
    //    // {

    //    // }

    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        speakUI.enabled = true;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        speakUI.enabled = false;
    //    }
    //}
}
