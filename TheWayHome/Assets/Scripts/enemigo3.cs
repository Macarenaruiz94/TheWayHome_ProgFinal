using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo3 : MonoBehaviour
{
    public float speed = 5f;
    private int Health = 2;
    private Rigidbody2D rb;
    public float deactivateTimer = 10f;

    void Start()
    {
        Invoke("DeactivateEnemigo", deactivateTimer);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            Health -= 1;

            if (Health == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void DeactivateEnemigo()
    {
        gameObject.SetActive(false);
    }
}
