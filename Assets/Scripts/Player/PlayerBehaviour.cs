using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
  [Header("Movement")]
  public Rigidbody2D rb;
  public static float speed = 10;
  public int jumpCount = 2;
  bool isGrounded = true;
  public static float inputSpeed;
  public float jumpForce = 600;
  public float knockbackForce = 20;
  public CapsuleCollider2D upCollider;
  public CapsuleCollider2D crawlCollider;
  public bool hurting = false;

  [Header("Physics")]
  public float knockbackDur;
  public float knockbackRange;

  [Header("Save System + HealthBar")]
  public static int strength;
  public int MaxStrength = 100;
  public static int health;
  public int MaxHealth = 100;
  public LifeBar lifeBar;
  public MagicBar magicBar;
  public bool isDead = false;
  public int coin;
  public LayerMask layerSave;
  public LayerMask layerBoss;


  [Header("Upgrade")] 
  public bool hasDoubleJump = false;
  public static bool hasFlameSword = true;
  public static bool hasBoneSword = true;


  [Header("animation")]
  public Animator anim;

  [SerializeField] private AudioSource musicaBoss;

  public static bool  calcado = false;

  void Start() {
    health = MaxHealth;
    strength = MaxStrength;
    lifeBar.setMaxHealth(MaxHealth);
    magicBar.setMaxStrength(MaxStrength);
    LoadPlayer();

  }
  void Update() {
    lifeBar.setHealth(health);
    magicBar.setStrength(strength);

    inputSpeed = Input.GetAxis("Horizontal");

    if (!Dash.dashing  && !hurting ) {
      rb.velocity = new Vector2(inputSpeed * speed, rb.velocity.y);
    }

    if (Input.GetButtonDown("Jump") && jumpCount > 0) {
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
    if (ray) {
      SavePlayer();
      Debug.Log("Salvo!");
    }

    RaycastHit2D rayBoss = Physics2D.Raycast(transform.position, Vector2.down, 2, layerBoss);
    if (rayBoss) {
      musicaBoss.Play();
    }

    if (Input.GetKeyDown(KeyCode.LeftControl)) {
      crawl();
    } else if (Input.GetKeyUp(KeyCode.LeftControl)) {
      stopCrawl();
    }

    dead();

  }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "ground") {
      if (!isGrounded) {
        anim.SetTrigger("FinishedJump");
      }
      isGrounded = true;
      jumpCount = 2;
    } else if (other.gameObject.layer == 9 || other.gameObject.layer == 12) {
      FindObjectOfType<AudioManager>().Play("danoSojobo");

      if (other.gameObject.tag == "Oni") {
        health -= 30;
        StartCoroutine(GetComponent<PlayerKnockback>().Knockback(knockbackDur, knockbackRange, transform.position));

      } else if (other.gameObject.tag == "RedOni") {
        health -= 35;
        StartCoroutine(GetComponent<PlayerKnockback>().Knockback(knockbackDur, knockbackRange, transform.position));

      } else {
        health -= 15;
        StartCoroutine(GetComponent<PlayerKnockback>().Knockback(knockbackDur, knockbackRange, transform.position));
      }         
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
    lifeBar.setHealth(health);
    magicBar.setStrength(strength);
  }

  void jump() {
    rb.velocity = new Vector2(0, 0);
    rb.AddForce(new Vector2(0, jumpForce));
    isGrounded = false;
    anim.SetTrigger("Jump");
    jumpCount--;
  }

  void dead() {
    if(health <= 0) {
      SceneManager.LoadScene("EndGameScene");
    }
  }

  void crawl() {
    anim.SetBool("Crawl", true);
    speed = 5;
    upCollider.enabled = false;
    crawlCollider.enabled = true;
  }

  void stopCrawl() {
    anim.SetBool("Crawl", false);
    speed = 10;
    crawlCollider.enabled = false;
    upCollider.enabled = true;
  }
}
