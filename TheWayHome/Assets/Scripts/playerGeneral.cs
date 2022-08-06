using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class playerGeneral : MonoBehaviour
{

    public float speed;
    public float jump;
    public float movimiento = 1;
    public Animator animator;
    private int Health = 5;
    public string sceneName;
    public Transform LaunchOffset;
    public GameObject ProyectilPrefab;
    Rigidbody2D rb;
    public bool mirandoDerecha = true;
    private bool isHurting;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    protected virtual void Awake()
    {
        Movement();
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject bullet = Instantiate(ProyectilPrefab);
            bullet.GetComponent<starBalaControl>().Move(mirandoDerecha);
            bullet.transform.position = LaunchOffset.transform.position;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("pinchitos"))
        {
            animator.SetBool("isTakenDmg", true);
            Destroy(gameObject);
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemigo")
        {
            Health -= 1;
            StartCoroutine("Hurt");

            if (Health == 0)
            {
                animator.SetBool("isTakenDmg", true);
                Destroy(gameObject);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
    IEnumerator Hurt()
    {
        isHurting = true;
        rb.velocity = Vector2.zero;

        if (mirandoDerecha)
            rb.AddForce(new Vector2(-200f, 200f));
        else
            rb.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(0.5f);

        isHurting = false;
    }

    public virtual void SetAnimationState()
    {
        if (movimiento == 0)
        {
            animator.SetBool("isMoving", false);
        }

        if (rb.velocity.y == 0)
        {
            animator.SetBool("isJumping", false);
        }

        if (Mathf.Abs(movimiento) > 0 && rb.velocity.y == 0)
        {
            animator.SetBool("isMoving", true);
        }
        else { animator.SetBool("isMoving", false); }

        if (rb.velocity.y > 0.001f)
        {
            animator.SetBool("isJumping", true);
        }
    }
}