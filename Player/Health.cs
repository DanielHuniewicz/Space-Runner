using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {


    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private PlayerPose ps;

    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPose>();

    }


    // Update is called once per frame
    void Update () {

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        if (health <= 0)
        {

            health = 0;



            ps.Die();
        }

            for (int i =0; i< hearts.Length; i++)
        {

            if(i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }

        
	}
    public void Damage (int dmg)
    {
        health -= dmg;
        gameObject.GetComponent<Animation>().Play("NewPlayer_hurt");
    }
    public void Addlife (int life)
    {
        health += life;
    }



}
