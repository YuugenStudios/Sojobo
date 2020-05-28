using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  public Animator anim;

  void Start() {
        
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.LeftShift)) {
      StartCoroutine(Attack());
    }
  }

  IEnumerator Attack() {
    if (GetComponent<Rigidbody2D>().velocity.y == 0) { 
      PlayerBehaviour.speed = 0;
    }

    anim.SetTrigger("Attack");

    yield return new WaitForSeconds(.20f);

    PlayerBehaviour.speed = 1500;
  }
}
