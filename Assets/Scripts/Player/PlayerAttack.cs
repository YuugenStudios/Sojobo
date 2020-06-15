using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public Animator anim;
  public Transform attackPoint;
  public float rangeAttack = 0.5f;
  public LayerMask enimelayers;

  public int SwordDamage = 20;

  void Update() {
    if (Input.GetKeyDown(KeyCode.LeftShift)) {
           FindObjectOfType<AudioManager>().Play("espadaSom");
            StartCoroutine(Attack());
    }
  }

  IEnumerator Attack() {
    if (GetComponent<Rigidbody2D>().velocity.y == 0) { 
      PlayerBehaviour.speed = 0;
    }

    anim.SetTrigger("Attack");

    yield return new WaitForSeconds(.20f);

    PlayerBehaviour.speed = 10;

    Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, rangeAttack, enimelayers); // cria um círculo na posição do attackPoint com um raio do rangeAttack e detecta as ccolisões no layer enimeLayers

    foreach (Collider2D enemy in hitEnemies) {
            FindObjectOfType<AudioManager>().Play("danoInimigo");
            enemy.GetComponent<Enemy>().TakeDamage(SwordDamage);
    }
  }
  void OnDrawGizmosSelected()  {
    if(attackPoint == null) {
      return;
    }
    Gizmos.DrawWireSphere(attackPoint.position,rangeAttack);
    //Gizmos.DrawWireSphere(attackPoint.position* -1,rangeAttack); //vai desenhar  um círculo no editor na posição do atackPoint e com o raio do rangeAttack
  }
}
