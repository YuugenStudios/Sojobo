using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   // public Animator animator;
    public int MaxHealth =100;
    int currentHealth;

    void Start()
    {
        currentHealth = MaxHealth;    
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        //animator.SetTrigger("hurt");
        if(currentHealth <= 0) {
            die();
        }
    }

    void die(){
        //animator.SetBool("IsDead",true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
