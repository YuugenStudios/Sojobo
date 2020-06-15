using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
  public float dashSpeed;
  public Rigidbody2D rigidbody;
  public KeyCode dashKey;
  public static bool dashing;
  public Animator animator;

  void Update() {
    if (Input.GetKeyDown(dashKey) && rigidbody.velocity.x > 0) {
      StartCoroutine(dashCoroutine(1));
    } else if (Input.GetKeyDown(dashKey) && rigidbody.velocity.x < 0) {
      StartCoroutine(dashCoroutine(-1));
    }

  }

  IEnumerator dashCoroutine(float lado) {
    FindObjectOfType<AudioManager>().Play("dash");
    dashing = true;
    animator.SetTrigger("Dash");
    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
    rigidbody.AddForce(new Vector2(dashSpeed * lado, 0f), ForceMode2D.Impulse);

    yield return new WaitForSeconds(.5f);

    dashing = false;
  }
}
