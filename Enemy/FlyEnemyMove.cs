using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemyMove : MonoBehaviour {

    public GameObject target;
    public float ratio = 0.05f;
    bool gotIt;
    public float range;



    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float step;

        if (!gotIt)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range);

            foreach (Collider2D h in hits)
                if (h.gameObject == target)
                {
                    gotIt = true;
                    break;
                }
        }


        if (gotIt)
        {
            if (Vector3.Dot(target.transform.position - transform.position, target.transform.localScale.x * Vector3.right) > 0)
            {
                step = ratio * 2;
            }
            else
            {
                step = ratio;
            }

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        Gizmos.DrawWireSphere(transform.position, range);
    }


}
