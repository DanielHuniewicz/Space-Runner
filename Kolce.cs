using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kolce : MonoBehaviour {

    //private CharacterController2D controller;
    private Health health;
    public int obrazenia;
    float nextDamage = 0.0f;
    public float damageRate = 0.5f;
    //public int knockbackPowerInEditor;


    // Use this for initialization
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

    }

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Time.time > nextDamage)
        {
            //nextDamage = Time.time + damageRate;
           // health.Damage(obrazenia);

           // StartCoroutine(controller.Knockback(0.02f, 350, controller.transform.position));
        }

        
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Time.time > nextDamage)
        {
            nextDamage = Time.time + damageRate;
            health.Damage(obrazenia);

            // StartCoroutine(controller.Knockback(0.02f, 350, controller.transform.position));
        }
    }
}
