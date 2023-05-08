using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectionRange : MonoBehaviour
{
    public float range = 10f;
    
    private void Update() {
        GetComponent<CircleCollider2D>().radius = range;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")) {
            var dir = other.transform.position - transform.position;
            Debug.DrawRay(transform.position, dir, Color.red);
            RaycastHit2D rayCast = Physics2D.Raycast(transform.position, dir);

            if (rayCast.collider != null){
                Debug.Log("test");
            }
            if (rayCast.collider.gameObject.tag == "Player"){
                Debug.Log("I see you");
            }
        }
    }
}
