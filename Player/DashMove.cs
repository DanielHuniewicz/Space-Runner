using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMove : MonoBehaviour {

    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public Mana mana;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(direction == 0)
        {
            if (Input.GetButton("Dash1") && Input.GetAxis("Horizontal") < 0 && mana.updatedMana >= 25 || Input.GetButtonDown("Dash1") && Input.GetAxis("Horizontal") < 0 && mana.updatedMana >= 25)
            {
                direction = 1;
                mana.UseMana();
            }
            else if(Input.GetButton("Dash1") && Input.GetAxis("Horizontal") > 0 && mana.updatedMana >= 25 || Input.GetButtonDown("Dash1") && Input.GetAxis("Horizontal") > 0 && mana.updatedMana >= 25)
            {
                direction = 2;
                mana.UseMana();
            }
              
        } else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;


            } else
            {
                dashTime -= Time.deltaTime;
                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                    gameObject.GetComponent<Animation>().Play("NewPlayer_dash");

                } 
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                    gameObject.GetComponent<Animation>().Play("NewPlayer_dash");
                }
            }
        }

	}
}
