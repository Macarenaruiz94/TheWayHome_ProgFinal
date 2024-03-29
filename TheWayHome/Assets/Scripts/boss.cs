using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour, ITakeDmg
{
    public float maxSpeed = 4f;
    public float speed = 4f;
    private Rigidbody2D rb;
    [SerializeField] int Health = 4;
    public Transform target;
    private bool mirandoDerecha = true;
    [SerializeField] float agroRange;
    private float timeBtwShots;
    [SerializeField] float startTimeBtwShots;
    [SerializeField] private GameObject EnemigoBala;
    [SerializeField] private Transform AtackPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float distToPlayer = Vector2.Distance(transform.position, target.position);

        if (distToPlayer < agroRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }

        Atacar();
    }

    public void Hit(int DamageTaken)
    {
        Health -= DamageTaken;

        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void Da�o(int DamageTaken)
    {
        Hit(DamageTaken);
    }

    void Atacar()
    {
        if (timeBtwShots <= 0)
        {
            Instantiate(EnemigoBala, AtackPoint.position, AtackPoint.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
