using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletDecay = 10f;
    private void Awake() {
        Destroy(this.gameObject, bulletDecay);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            
        }
        else{
            Destroy(this.gameObject);
        }
        
    }
}
