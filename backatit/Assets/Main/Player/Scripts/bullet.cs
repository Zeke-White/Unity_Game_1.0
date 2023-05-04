using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float coolDown;
    public float coolDownTime = 2f;
    public Rigidbody2D BulletPre;
    public float attackSpeed = 10f;
    public float moveSpeed = 100f;
    

    private void Update() {
        
        if (Input.GetButton("Fire1")){
            if(coolDown <= Time.time){
                shoot();
            }
        }

    }
    private void shoot(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Rigidbody2D clone;
        Debug.Log(transform.rotation);
        clone = Instantiate(BulletPre, transform.position, transform.rotation);
        clone.velocity = transform.TransformDirection(transform.right * moveSpeed);

        coolDown = Time.time + coolDownTime;
    }

}
