using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp = 10;
    

    public void damage(int dmg){
        hp -= dmg;
        Debug.Log("oww");
    }
}
