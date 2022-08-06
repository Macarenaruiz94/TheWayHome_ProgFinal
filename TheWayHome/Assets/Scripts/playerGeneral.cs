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
    private bool mirandoDerecha = true;
    private float y;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        y = GetComponent<Rigidbody2D>().velocity.y;
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
}