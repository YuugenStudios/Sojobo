/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneScript : MonoBehaviour
{
  public Rigidbody2D rb;
  public float velocity;
  bool last;

  void Start() {
    if (EskeletonScript.lefty) {
      rb.velocity = new Vector3(velocity * Time.deltaTime, 0);
    }
    else {
      rb.velocity = new Vector3(-velocity * Time.deltaTime, 0);
    }
  }

  void OnCollisionEnter2D(Collision2D collision) {
    if (collision.gameObject.name == "Player") {
      print("dano");
    }
    Destroy(this.gameObject);
  }

  void OnBecameInvisible() {
    Destroy(this.gameObject);
  }
}*/
