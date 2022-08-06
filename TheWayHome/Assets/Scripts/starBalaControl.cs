using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBalaControl : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    public void Move(bool mirandoDerecha)
    {
        if(mirandoDerecha)
        {
            rb.velocity = new Vector2(speed, 0);
        } else { rb.velocity = new Vector2(-speed, 0); }

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
