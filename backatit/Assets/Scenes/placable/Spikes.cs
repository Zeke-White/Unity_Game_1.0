using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{   
    private GameObject player;
    private Health health;   
    void Awake()
    {  
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Health>();
    }

    
    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("S");
        if(collision.gameObject.CompareTag("Player")) {
            health.damage(1);
        }
    }
    
}
