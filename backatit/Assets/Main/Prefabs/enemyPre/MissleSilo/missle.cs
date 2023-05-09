using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle : MonoBehaviour
{
    public float missleDecay = 10f;
    private Health health;   
    public float armTime = 2f;
    public float armTimer;

    public float speed = 2f;
    private Transform player;

    public BoxCollider2D missleCollider;

    private void Awake() {
        Destroy(this.gameObject, missleDecay);
        armTimer = Time.time + armTime;
        
    }

    private void Update() {
        if(armTimer <= Time.time){
            missleCollider.enabled = true;
        }
        chasePlayer();

    }

    private void chasePlayer(){
        
        this.player = GameObject.FindWithTag("Player").transform;
        var target = player.position;
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
    }

    void OnCollisionEnter2D(Collision2D collision){

        try{
            health = collision.gameObject.GetComponent<Health>();
            health.damage(1);
        }
        catch{
            Debug.Log("No health script, Missle");
        }
        Destroy(this.gameObject);
    }
}
