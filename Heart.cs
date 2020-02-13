using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private Health health;
    public int life;
    float nextLife = 0.0f;
    public float lifeRate = 0.5f;
    public AudioClip MusicClip;
    public AudioSource MusicSource;

    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        MusicSource.clip = MusicClip;
    }


    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && Time.time > nextLife && health.health <5)
        {
            nextLife = Time.time + lifeRate;
            health.Addlife(life);
            MusicSource.Play();
            Destroy(gameObject);

        }
    }
}
