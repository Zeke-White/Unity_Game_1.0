using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    public float missleDecay = 10f;
    private Health health;   
    public float armTime = 2f;
    public float armTimer;

    public BoxCollider2D missleCollider;

    private void Awake() {
        Destroy(this.gameObject, missleDecay);
        armTimer = Time.time + armTime;
    }

    private void Update() {
        if(armTimer <= Time.time){
            missleCollider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other){

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
