using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionRange : MonoBehaviour
{
    public float range = 10f;

    public float reloadCoolDown = 2f;
    public float reloadTime;

    public int numMissle = 3;
    public GameObject misslePre;


    
    private void Update() {
        GetComponent<CircleCollider2D>().radius = range;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            var dir = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, dir, Color.red);
            RaycastHit2D rayCast = Physics2D.Raycast(transform.position, dir);
            if (rayCast.collider.gameObject.tag == "Player"){
                if(reloadTime <= Time.time){
                    fire();
                }
            }
        }
    }

    private void fire(){
        for(int i = 0; i < numMissle; i++){
            GameObject missle = (GameObject)Instantiate(misslePre, transform.position, Quaternion.identity);
        }
        reloadTime = Time.time + reloadCoolDown;
    }   
}
