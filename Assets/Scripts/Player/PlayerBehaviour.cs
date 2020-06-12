using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
  [Header("Movement")]
  public Rigidbody2D rb;
  public static float speed = 10;
  bool isGrounded = true;
  public static float inputSpeed;
  public float jumpForce = 600;

  [Header("Save System")]
  public int coin;
  public int strength;
  public int health;
  public int MaxHealth = 100;
  public LayerMask layerSave;

  [Header("animation")]
  public Animator anim;
  void Start() {
    LoadPlayer();
  }
  void Update() {
    inputSpeed = Input.GetAxis("Horizontal");
    if (!Dash.dashing) {
      rb.velocity = new Vector2(inputSpeed * speed, rb.velocity.y);
    }

    if (Input.GetButtonDown("Jump") && isGrounded) {
      jump();
    }

    anim.SetFloat("Speed", Mathf.Abs(inputSpeed));

    if (inputSpeed > 0) {
      GetComponent<Transform>().localScale = new Vector3(0.743799f, 0.743799f, 0.743799f);
    }
    else if (inputSpeed < 0) {
      GetComponent<Transform>().localScale = new Vector3(-0.743799f, 0.743799f, 0.743799f);
    }

    RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down, 1, layerSave);
    if ( ray && Input.GetKeyDown(KeyCode.R)) {
      SavePlayer();
      Debug.Log("Salvo!");
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "ground") {
      if (!isGrounded) {
        anim.SetTrigger("FinishedJump");
      }
      isGrounded = true;
    }
  }

  public void SavePlayer() {
    Save.SavePlayer(this);
  }
  public void LoadPlayer() {
    PlayerData data = Save.LoadPlayer();

    Vector3 position;
    position.x = data.position[0];
    position.y = data.position[1];
    position.z = data.position[2];
    transform.position = position;

    health = data.health;
    coin = data.coin;
    strength = data.strength;
  }

  void jump() {
    rb.velocity = new Vector2(0, 0);
    rb.AddForce(new Vector2(0, jumpForce));
    isGrounded = false;
    anim.SetTrigger("Jump");
  }
}
