using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl2 : playerGeneral
{
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
        jump = jump * 2;
    }
}
