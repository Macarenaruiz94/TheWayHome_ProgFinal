using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ITakeDmg dmg = collision.gameObject.GetComponent<ITakeDmg>();

        if (dmg != null)
        {
            dmg.Daño(1);
        }
    }
}
