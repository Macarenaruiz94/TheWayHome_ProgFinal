using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl2 : playerGeneral
{
    public Transform LaunchOffset2;
    void Update()
    {
        Movement();
    }

    public override void Movement()
    {
        base.Movement();

        HabilidadEspecial();
    }

    void HabilidadEspecial()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(ProyectilPrefab, LaunchOffset2.position, LaunchOffset2.transform.rotation);
        }
    }
}
