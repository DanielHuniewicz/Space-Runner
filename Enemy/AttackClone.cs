using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackClone : MonoBehaviour {

    public Turret turret;

    public bool isLeft = false;


    void Awake()
    {
        turret = gameObject.GetComponentInParent<Turret>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (isLeft)
            {
                turret.Attack(false);
            }
            else
            {
                turret.Attack(true);
            }
        }
    }


  
}
