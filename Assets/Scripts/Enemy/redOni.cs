using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redOni : MonoBehaviour {
  public float rayDistance;
  public float speed;
  public Animator anim;
  public Rigidbody2D rigidbody;

  void Update() {
    rigidbody.velocity = Vector2.left * speed;
    RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, rayDistance);  

    if (hit && hit.collider.CompareTag("Player")) {
      anim.SetTrigger("hit");
      //pedro faz o attackScript aki pfv
    } else if (hit && hit.collider.tag != "Player") {
      transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }    
  }

  private void OnDrawGizmos() {
    Debug.DrawRay(transform.position, Vector2.left * rayDistance, Color.blue);
  }
}
