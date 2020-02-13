using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public Transform[] point;
    public int startingPoint;
    public int targetPoint;
    public float speed;
    
	void Start ()
    {
                transform.position = point[startingPoint].position;
    }
	
		void Update ()
    {
        transform.position = Vector2.MoveTowards(transform.position, point[targetPoint].position, speed * Time.deltaTime);
        if (transform.position == point[targetPoint].position) 
        {
            targetPoint++;
            if (targetPoint == point.Length)
            {
                targetPoint = 0;
            }

        }
    }
}
