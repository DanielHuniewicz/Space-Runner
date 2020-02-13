using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioSource MusicSource;

    private void Start()
    {
        MusicSource.clip = MusicClip;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) {
            MusicSource.Play();
            ScoreTextScript.coinAmount += 10;
            Destroy(gameObject);
        }
          
    }
}
