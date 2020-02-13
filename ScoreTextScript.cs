using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {

    Text text;

    public Text textFinal;
    public Text scoreFinal;
    public Timer time;

    float punkty;

    public static int coinAmount;
    

	void Start () {

        text = GetComponent<Text>();
	}

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
        //textFinal.text = text.text;

        punkty = (400 + (coinAmount) * 100 - time.t * 50);
        //scoreFinal.text = ((coinAmount)*100 - time.t).ToString();
        if (punkty < 0)
        {
            punkty = 100;
        }


        scoreFinal.text = punkty.ToString("0.00");
    }
}
