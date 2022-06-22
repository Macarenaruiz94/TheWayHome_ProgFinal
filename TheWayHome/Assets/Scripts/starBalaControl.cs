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
        Vector3 temp = transform.position;
        temp.x += speed * Time.deltaTime;
        transform.position = temp;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDmg dmg = collision.gameObject.GetComponent<ITakeDmg>();

        if (dmg != null)
        {
            dmg.Da�o(1);
        }

        Destroy(gameObject);
    }
}
