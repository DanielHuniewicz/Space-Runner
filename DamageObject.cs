using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour {

    private Health health;
    public int obrazenia;
    float nextDamage = 0.0f;
    public float damageRate = 0.5f;
        
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Time.time > nextDamage)
        {

        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Time.time > nextDamage)
        {
            nextDamage = Time.time + damageRate;
            health.Damage(obrazenia);
        }
    }
}
