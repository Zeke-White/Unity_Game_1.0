using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firePoint : MonoBehaviour
{
    private float coolDown;
    public float coolDownTime = 2f;
    public Rigidbody2D BulletPre;
    public float attackSpeed = 10f;
    public float moveSpeed = 100f;

    public int ammunition = 4; 
    public int ammunitionUsed;
    public float reloadTime = 4f;
    private float reloadTimeHolder;
    
    

    private void Update() {

        if(reloadTimeHolder <= Time.time){
            if (Input.GetButton("Fire1")){
                if(ammunitionUsed < ammunition){
                    if(coolDown <= Time.time){
                        ammunitionUsed++;
                        shoot();
                    }
                }
                else{
                    Debug.Log("Reloading");
                    ammunitionUsed = 0;
                    reloadTimeHolder = Time.time + reloadTime;
                }
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
