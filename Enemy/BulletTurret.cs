using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour {

   

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.isTrigger != true)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Health>().Damage(1);
            }
            Destroy(gameObject);
        }
    }
}
