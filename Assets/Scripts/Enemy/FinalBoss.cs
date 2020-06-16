using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour {
  [Header("Timers")]
  public float teleportDelay;
  public float teleportEndDelay;
  public float returnDelay;
  public float stunTime;

  [Header("Components")]
  public Animator anim;
  public Rigidbody2D rigidbody;
  public CapsuleCollider2D collider;
  public Transform Player;

  [Header("Position markers")]
  public Transform[] teleporters;
  public Transform startPosition;

  public float dashSpeed;

  public static bool explosionCollided = false;
  bool Attack = true;
  int random;

  bool shouldStun;

  void Start() {
    InvokeRepeating("attackLoop", 5f, 5f);
  }

  void attackLoop() {
    print("starting loop");
    StartCoroutine(teleport());
  }

  IEnumerator teleport() {
    GetComponent<SpriteRenderer>().flipX = false;
    rigidbody.velocity = new Vector2(0, 0);
    explosionCollided = false;
    collider.enabled = false;
    
    if (!shouldStun) {
      anim.SetTrigger("teleport");
      random = Random.Range(0, 3);

      yield return new WaitForSeconds(teleportDelay);

      transform.position = teleporters[random].position;

      StartCoroutine(attack());
    } else if (shouldStun) {
      print("stunned");

      yield return new WaitForSeconds(stunTime);

      print("time is over my friend");
      shouldStun = false;
      // attackLoop();
      // StartCoroutine(recall());
    }
  }

  IEnumerator attack() {
    anim.SetTrigger("attack");
    
    yield return new WaitForSeconds(teleportEndDelay);

    if (explosionCollided) {
      StartCoroutine(recall());
    } else {
      collider.enabled = true;

      switch (random) {
        case 0:
          rigidbody.velocity = new Vector2(dashSpeed, 0);
          break;

        case 1:
          if (Player.position.x >= -2.95f) {
            rigidbody.velocity = new Vector2(dashSpeed, 0);
          } else {
            GetComponent<SpriteRenderer>().flipX = true;
            rigidbody.velocity = new Vector2(-dashSpeed, 0);
          }
          break;

        case 2: 
          GetComponent<SpriteRenderer>().flipX = true;
          rigidbody.velocity = new Vector2(-dashSpeed, 0);
          break;
      }
    }
  }

  IEnumerator recall() {
    anim.SetTrigger("teleport");

    yield return new WaitForSeconds(returnDelay);

    transform.position = startPosition.position;
    anim.SetTrigger("return");
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.collider.CompareTag("ground")) {
      rigidbody.velocity = new Vector2(0, 0);
      collider.enabled = false;
      shouldStun = true;
    }
  }
}
