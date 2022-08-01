using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class playerGeneral : MonoBehaviour
{

    public float speed;
    public float jump;
    public float movimiento;
    private int Health = 5;
    public string sceneName;
    public Transform LaunchOffset;
    public GameObject ProyectilPrefab;
    Rigidbody2D rb;
    public Animator animator;
    private bool mirandoDerecha = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    protected virtual void Awake()
    {
        Movement();
        SetAnimationState();
    }
    public virtual void Movement()
    {
        movimiento = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movimiento, 0, 0) * Time.deltaTime * speed;

        if (movimiento > 0 && !mirandoDerecha)
        {
            Girar();
        }
        else if (movimiento < 0 && mirandoDerecha)
        {
            Girar();
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProyectilPrefab, LaunchOffset.position, transform.rotation);
        }
    }
    public virtual void Girar()
    {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    public virtual void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene(sceneName);
            }
        }
    }

    public void SetAnimationState()
    {
        if (movimiento == 0)
        {
            animator.SetBool("isRunning", false);
        }

        if (rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (Mathf.Abs(movimiento) == 12 && rb.velocity.y == 0)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);

        if (rb.velocity.y > 0)
            animator.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
    }
}