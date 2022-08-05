using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBalaControl : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDmg dmg = collision.gameObject.GetComponent<ITakeDmg>();

        if (dmg != null)
        {
            dmg.Daño(1);
        }

        Destroy(gameObject);
    }
}
