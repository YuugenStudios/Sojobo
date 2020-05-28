using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
  [Header("Movement")]
  public Rigidbody2D rb;
  public static float speed = 1500;
  bool isGrounded = true;
  public static float inputSpeed;
  public float jumpForce = 600;

  [Header("animation")]
  public Animator anim;

  void Update() {
    inputSpeed = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(inputSpeed * speed * Time.deltaTime, rb.velocity.y);

    if (Input.GetButtonDown("Jump") && isGrounded) {
      rb.velocity = new Vector2(0, 0);
      rb.AddForce(new Vector2(0, jumpForce));
      isGrounded = false;
      anim.SetTrigger("Jump");

    }

    anim.SetFloat("Speed", Mathf.Abs(inputSpeed));

    if (inputSpeed > 0) {
      GetComponent<SpriteRenderer>().flipX = false;
    } else if (inputSpeed < 0) {
      GetComponent<SpriteRenderer>().flipX = true;
    }
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "ground") {
      if (!isGrounded)  {
        anim.SetTrigger("FinishedJump");
      }
      isGrounded = true;
    }
  }
}
