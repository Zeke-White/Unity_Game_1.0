using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 10;
    public GameObject Object;


    public void damage(int dmg){
        hp -= dmg;
    }

    public void Update() {
        if (hp <= 0){
            Destroy(Object);
        }
    }
}
