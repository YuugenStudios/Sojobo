using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
  RaycastHit2D hit;
  public LayerMask layer;
  bool canClimb = false;
  public float distance;
  public Rigidbody2D rb;
  public float speed;
  public Animator anim;
  public Sprite climbSprite;

  void Update() {

  }

  void FixedUpdate() {
    if (PlayerBehaviour.inputSpeed > 0) {
      hit = Physics2D.Raycast(transform.position, Vector2.right, distance, layer);
    } else if (PlayerBehaviour.inputSpeed < 0) {
      hit = Physics2D.Raycast(transform.position, Vector2.left, distance, layer);
    }

    if (hit) {
      canClimb = true;
    } else {
      canClimb = false;
      rb.gravityScale = 5;
    }

    if (canClimb && Input.GetKeyDown(KeyCode.C)) {
      rb.gravityScale = 0;
      rb.velocity = new Vector2(0, Input.GetAxis("Vertical") * speed);
      anim.SetTrigger("Climb_Stopped");
    }

    if (canClimb && rb.velocity.y != 0) {
      anim.SetBool("Climb", true);
    } else {
      anim.SetBool("Climb", false);
      anim.SetTrigger("Climb_Stopped");
    }

    if (Input.GetKeyUp(KeyCode.C)) {
      rb.velocity = new Vector2(rb.velocity.x, 0);
      rb.gravityScale = 5;
      canClimb = false;
      anim.SetBool("Climb", false);
      anim.SetTrigger("StopClimb");
    }

    if (!canClimb) {
      rb.gravityScale = 5;
    }
  }
}
