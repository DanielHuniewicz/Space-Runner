using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

 

    //Floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed = 100;
    public float bulletTimer;

    //Booleans
    public bool awake = false;
    public bool lookingRight = true;

    //References
    public GameObject bullet;
    //public GameObject coinObject;

    public Transform target;
    public Transform shootPointLeft;
    public Transform shootPointRight;

    public AudioClip MusicClip;
    public AudioSource MusicSource;
    //public Transform coinPoint;

    //public Animator anim;


    // Use this for initialization
    void Start () {
        MusicSource.clip = MusicClip;
    }
	
	// Update is called once per frame
	void Update () {

        if (target != null) {
            RangeCheck();

            if (target.transform.position.x > transform.position.x)
            {
                lookingRight = true;
            }

            if (target.transform.position.x < transform.position.x)
            {
                lookingRight = false;
            }
        }
            
               
    }

 

    void RangeCheck()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance < wakeRange)
        {
            awake = true;
        }

        if (distance > wakeRange)
        {
            awake = false;
        }
    }

    public void Attack(bool attackingRight)
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 directon = target.transform.position - transform.position;
            directon.Normalize();
            MusicSource.Play();

            if (!attackingRight)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = directon * bulletSpeed;

                bulletTimer = 0; 

            }
            
             if (attackingRight)
             {
                 GameObject bulletClone;
                 bulletClone = Instantiate(bullet, shootPointRight.transform.position, shootPointRight.transform.rotation) as GameObject;
                 bulletClone.GetComponent<Rigidbody2D>().velocity = directon * bulletSpeed;

                 bulletTimer = 0;
             }
             
        }
    }

  
}
