using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour

{

    // public float offset;
    
    [SerializeField] private bool m_FacingRight;
    public GameObject BulletRight;
    public GameObject BulletLeft;
    public Transform shotPoint;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;




    private void Update()
    {
        // Handles the weapon rotation
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);


        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;


            if (m_FacingRight)
            {
                Instantiate(BulletRight, shotPoint.position, Quaternion.identity);
            }
            else
            {
                 Instantiate(BulletLeft, shotPoint.position, Quaternion.identity);
            }

        }
          
        

        // if(Input.GetMouseButton(0) && !m_FacingRight)
        // {
        //    Instantiate(BulletLeft, shotPoint.position, Quaternion.identity);
        //}

    }

}