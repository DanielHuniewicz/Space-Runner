﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    
    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
            col.transform.position = respawnPoint.position;
                }
}
