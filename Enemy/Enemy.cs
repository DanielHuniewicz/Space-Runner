using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed;
    public float stoppingDistance;
    public float nearDistance;

    public float startTimeBtwShots;
    public float timeBtwShots;

    public GameObject shot;
    private Transform player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(transform.position,player.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position,player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position,player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position)> nearDistance)
        {
            transform.position = this.transform.position;
        }

        if(timeBtwShots <= 0)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
	}
}
