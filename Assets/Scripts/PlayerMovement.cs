using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine.Android;
using TMPro;
using System.Linq;


public class PlayerMovement : MonoBehaviour
{

    public InputAction playerControls;
    public float moveSpeed = 5f;
    private Rigidbody2D player;
    private Vector2 moveDirection = Vector2.zero;
    public Sprite walkDown;
    public Sprite walkUp;
    public Sprite walkLeft;
    public Sprite walkRight;
    private SpriteRenderer playerSprite;
    public TextMeshProUGUI speakUI;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
        playerSprite = this.GetComponent<SpriteRenderer>();
        speakUI.text = $"{playerControls.controls[4].name.ToUpper()} Talk";
        speakUI.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();

        if (playerControls.ReadValue<Vector2>().x == 1)
        {
            playerSprite.sprite = walkRight;
        }

        if (playerControls.ReadValue<Vector2>().x == -1)
        {
            playerSprite.sprite = walkLeft;
        }

        if (playerControls.ReadValue<Vector2>().y == 1)
        {
            playerSprite.sprite = walkUp;
        }

        if (playerControls.ReadValue<Vector2>().y == -1)
        {
            playerSprite.sprite = walkDown;
        }
    }

    private void FixedUpdate()
    {
        player.linearVelocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.gameObject.CompareTag("Enemy"))
        // {

        // }

        if (collision.gameObject.CompareTag("NPC"))
        {
            speakUI.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            speakUI.enabled = false;
        }
    }
}
