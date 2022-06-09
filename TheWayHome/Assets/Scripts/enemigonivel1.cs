using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigonivel1 : MonoBehaviour
{
    public float maxSpeed = 4f;
    public float speed = 4f;
    private Rigidbody2D rb2d;
    private int Health = 2;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb2d.AddForce(Vector2.right * speed);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bala"))
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
