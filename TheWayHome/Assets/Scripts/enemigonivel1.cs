using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigonivel1 : MonoBehaviour, ITakeDmg
{
    [SerializeField] float maxSpeed = 4f;
    [SerializeField] float speed = 4f;
    private Rigidbody2D rb;
    [SerializeField] int Health = 2;
    [SerializeField] Transform target;
    private bool mirandoDerecha = true;
    [SerializeField] float agroRange;
    [SerializeField] Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);

        if (distToPlayer < agroRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            LookPlayer();
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    public void LookPlayer()
    {
        if ((target.position.x > transform.position.x && !mirandoDerecha) || (target.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Hit(int DamageTaken)
    {
        Health -= DamageTaken;

        if (Health == 0)
        {
            animator.SetTrigger("isDead");
            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void Daño(int DamageTaken)
    {
        Hit(DamageTaken);
    }
}
