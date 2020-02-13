using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fliper : MonoBehaviour
{
    public SpriteRenderer sr;
    public bool prawy;

    float nextFlip = 0.0f;
    public float flipRate = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("zamykanie aplikacji");
        if (col.CompareTag("Enemy") && prawy == true)
        {
            sr.flipX = true;
        }
        else if (col.CompareTag("Enemy") && prawy == false)
            {
                sr.flipX = false;
            }
    }
}
