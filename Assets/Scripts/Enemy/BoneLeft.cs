using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneLeft : MonoBehaviour {
  public Rigidbody2D rb;
  public float velocity;
  bool last;

  void Start() {
    rb.velocity = new Vector3(-velocity, 0);
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
}
