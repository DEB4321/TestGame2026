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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        player.linearVelocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
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
