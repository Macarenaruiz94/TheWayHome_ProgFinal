using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class playerGeneral: MonoBehaviour {

    public float speed;

    protected virtual void Awake()
    {
        Movement();
        Atack();
    }
    void Movement()
    {
        
    }

    void Atack()
    {
        
    }
}
