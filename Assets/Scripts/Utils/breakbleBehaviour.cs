using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakbleBehaviour : MonoBehaviour
{
   public int MaxHealth =100;
    int currentHealth;
    

    void Start()
    {
        
        currentHealth = MaxHealth;    
    }

    public void TakeDamage(int damage) {

       //if(PlayerBehaviour.hasBoneSword == true) { 
        currentHealth -= damage;

        //animator.SetTrigger("hurt");
        if (currentHealth <= 0) {
            FindObjectOfType<AudioManager>().Play("danoInimigo");
            die();
        }
      // }
    }

    void die(){
        //animator.SetBool("IsDead",true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        
    }
}
