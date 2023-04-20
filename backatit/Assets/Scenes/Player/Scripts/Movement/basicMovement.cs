using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMovement : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    private Vector2 input;

    public float moveSpeed;

    private float activeMoveSpeed;
    public float dashMoveSpeed;
    public float dashCoolDown = 0.5f;
    public float dashLength = 1f;
    public float dashCoolDownCounter;
    public float dashCounter;



    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    void Update() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        rigidBody.velocity = input * activeMoveSpeed;

        if (Input.GetKeyDown(KeyCode.Space)){
            if(dashCoolDownCounter <= 0 && dashCounter <= 0){
                activeMoveSpeed = dashMoveSpeed;
                dashCounter = dashLength;
            }
        }
        
        if (dashCounter > 0){
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0){
                activeMoveSpeed = moveSpeed;
                dashCoolDownCounter = dashCoolDown;
            }
        }

        if (dashCoolDownCounter > 0){
            dashCoolDownCounter -= Time.deltaTime;
        }
    }
}

// i like coding!