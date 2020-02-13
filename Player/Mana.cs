using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour {

    public float maxMana;
    public float pointIncreasedPerSecond;
    public float manaCost;
    public float updatedMana;
    public Text manaUI;


	// Use this for initialization
	void Start () {
        pointIncreasedPerSecond = 1f;
        updatedMana = 100;
        maxMana = 100;
        manaCost = 25;
		
	}
	
	// Update is called once per frame
	void Update () {

        updatedMana += pointIncreasedPerSecond * Time.deltaTime;

        if(updatedMana > maxMana)
        {
            updatedMana = 100;
        }
        if(updatedMana < 0)
        {
            updatedMana = 0;
        }

        /*
        if (Input.GetKeyDown(KeyCode.C))
        {
            UseMana();
        }
        */

        manaUI.text = (int)updatedMana + "";
	}

   

    public void UseMana()
    {
        
        if(updatedMana >= manaCost)
       {
           updatedMana = updatedMana - manaCost;
       }
    }
}
