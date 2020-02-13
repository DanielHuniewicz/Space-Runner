using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_Enemy : MonoBehaviour
{

    public int curHealth;
    public int maxHealth;
    [SerializeField]
    private GameObject splash;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    //private bool m_FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        if (curHealth <= 0)
        {

            curHealth = 0;
            Destroy(gameObject);

        }

    }

    public void TakeDamage(int dmg)
    {
        curHealth -= dmg;

        if (curHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        MusicSource.Play();
        Instantiate(splash, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
      
    }

  

}
