using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePoint : MonoBehaviour
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
        Rigidbody2D clone;
        clone = Instantiate(BulletPre, transform.position, transform.rotation);
        clone.velocity = transform.right * moveSpeed;

        coolDown = Time.time + coolDownTime;
        
    }
}
