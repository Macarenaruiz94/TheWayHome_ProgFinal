using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puertaControl : MonoBehaviour
{
    [SerializeField] private int cantLlave = 10;
    private int llavesActuales;

    [SerializeField] private Text ItemText;

    public void AbrirPuerta()
    {
        llavesActuales++;
        ItemText.text = "Keys: " + llavesActuales;

        if (llavesActuales >= cantLlave)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        Item.Llave += AbrirPuerta;
    }

    private void OnDisable()
    {
        Item.Llave -= AbrirPuerta;
    }
}
