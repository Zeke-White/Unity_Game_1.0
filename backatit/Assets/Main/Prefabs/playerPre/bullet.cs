using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletDecay = 10f;
    private Health health;   
    private void Awake() {
        Destroy(this.gameObject, bulletDecay);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            
        }
        else{
            try{
                health = other.gameObject.GetComponent<Health>();
                health.damage(1);
            }
            catch{
                Debug.Log("No health script");
            }
            Destroy(this.gameObject);
        }
        
    }
}
