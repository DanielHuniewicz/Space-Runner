using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float velX = 5f;
    float velY = 0f;
  
    Rigidbody2D rb;
    private walk_Enemy dmg;
    public int shootDamage;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    

    }
	
	// Update is called once per frame
	void Update () {

        /*
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if(hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Destroy(gameObject);
            }
            Destroy(gameObject);
        }
        */
        rb.velocity = new Vector2(velX, velY);
        
        Destroy(gameObject, 3f);
                   
      
    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<walk_Enemy>().TakeDamage(shootDamage);
                
            }
            Destroy(gameObject);
        }
    }


}
