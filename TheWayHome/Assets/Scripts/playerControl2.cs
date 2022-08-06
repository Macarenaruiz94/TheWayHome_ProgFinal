using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl2 : playerGeneral
{
    public Transform LaunchOffset2;
    void Update()
    {
        Movement();
        SetAnimationState();
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
            GameObject bullet = Instantiate(ProyectilPrefab);
            bullet.GetComponent<starBalaControl>().Move(mirandoDerecha);
            bullet.transform.position = LaunchOffset2.transform.position;
        }
    }
}
