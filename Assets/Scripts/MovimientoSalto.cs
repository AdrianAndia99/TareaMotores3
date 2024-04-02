using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoSalto : MonoBehaviour
{
    public float speed;
    public float jumpforce;
    private float moveInput;
    public string LoseScene;

    private SpriteRenderer spriteRenderer;
    private Color colorJugador;

    private Rigidbody2D rb2D;

    private bool isGrounded;
    public Transform groundCheck;
    public float check;
    public LayerMask whatIsGround;
    private int extraJump;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colorJugador = GetComponent<SpriteRenderer>().color;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, check, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(moveInput * speed, rb2D.velocity.y);
    }
    void Update()
    {
        if(isGrounded == true)
        {
            extraJump = 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJump > 0)
        {
            rb2D.velocity = Vector2.up * jumpforce;
            extraJump--;
        }else if(Input.GetKeyDown(KeyCode.Space) && extraJump == 0 && isGrounded == true)
        {
            rb2D.velocity = Vector2.up * jumpforce;
        }        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Obtener el color del objeto
            Color colorObjeto = spriteRenderer.color;

            // Comprobar si el jugador y el objeto tienen el mismo color
            if (colorJugador == colorObjeto)
            {
                // Permitir que el jugador atraviese el objeto
                Physics2D.IgnoreCollision(collision.collider, GetComponent<Collider2D>());
            }
        }

        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(LoseScene);
            PlayerPrefs.DeleteKey("PuntajeGuardado");
        }
    }
}