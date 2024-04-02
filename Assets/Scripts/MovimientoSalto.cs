using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class MovimientoSalto : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    public int maxJumps = 2;
    int JumpsRemaining;
    private float moveInput;
    public string LoseScene;

    private SpriteRenderer spriteRenderer;
    private Color colorJugador;

    private Rigidbody2D rb2D;

    private bool isGrounded;
    public Transform groundCheck;
    public float check;
    public LayerMask whatIsGround;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorJugador = GetComponent<SpriteRenderer>().color;
    }
    void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, check, whatIsGround);

       // moveInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
    }
    void Update()
    {
        Isgrounded();

    }
    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>().x;
        Debug.Log("me muevo");
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (JumpsRemaining > 0)
        {
            if (context.performed)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpforce);
                JumpsRemaining--;
            }else if (context.canceled)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
                JumpsRemaining--;
            }
            Debug.Log("SALTA");

        }
    }
    private void Isgrounded()
    {
        if(Physics2D.OverlapCircle(groundCheck.position, check, whatIsGround))
        {
            JumpsRemaining = maxJumps;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(LoseScene);
            PlayerPrefs.DeleteKey("PuntajeGuardado");
        }
    }
}