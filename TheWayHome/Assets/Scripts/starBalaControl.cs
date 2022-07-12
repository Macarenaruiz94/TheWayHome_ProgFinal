using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBalaControl : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.position += transform.right * Time.deltaTime * speed;
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
