using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerGeneral: MonoBehaviour {

    public float speed;
    public float jump;
    public Transform LaunchOffset;
    Rigidbody2D rb;

    protected virtual void Awake()
    {
        Movement();
    }
    public virtual void Movement()
    {
        var movimiento = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movimiento, 0, 0) * Time.deltaTime * speed;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate(ProyectilPrefab, LaunchOffset.position, LaunchOffset.transform.rotation);
        }
    }
}
