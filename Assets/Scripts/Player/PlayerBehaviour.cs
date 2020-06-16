using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
  [Header("Movement")]
  public Rigidbody2D rb;
  public static float speed = 10;
  bool isGrounded = true;
  public static float inputSpeed;
  public float jumpForce = 600;
  public float knockbackForce = 2;

  [Header("Save System + HealthBar")]
  public int strength;
  public int MaxStrength = 100;
  public int health;
  public int MaxHealth = 100;
  public LifeBar lifeBar;
  public MagicBar magicBar;
  public bool isDead = false;

  public int coin;
  public LayerMask layerSave;
  public LayerMask layerBoss;

<<<<<<< HEAD
  [Header("Upgrade")] 
    static public bool hasDoubleJump = false;
    static public bool hasBoneSword = true;
    static public bool hasFlamerSword = false;
=======

    [Header("Upgrade")] 
    public bool hasDoubleJump = false;
>>>>>>> 5881607b9fffc9fff38fee6c8f3bae02c4f40e63

  [Header("animation")]
  public Animator anim;

    [SerializeField] private AudioSource musicaBoss;

    void Start() {
    health = MaxHealth;
    strength = MaxStrength;
    lifeBar.setMaxHealth(MaxHealth);
    magicBar.setMaxStrength(MaxStrength);
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
    if (ray) {
      SavePlayer();
      Debug.Log("Salvo!");
    }

<<<<<<< HEAD
    dead();
  }
=======
        RaycastHit2D rayBoss = Physics2D.Raycast(transform.position, Vector2.down, 2, layerBoss);
        if (rayBoss)
        {
            musicaBoss.Play();
        }

    }
>>>>>>> 5881607b9fffc9fff38fee6c8f3bae02c4f40e63

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.tag == "ground") {
      if (!isGrounded) {
        anim.SetTrigger("FinishedJump");
      }
      isGrounded = true;
    }

    else if (other.gameObject.layer == 9 || other.gameObject.layer == 12)
        {
            FindObjectOfType<AudioManager>().Play("danoSojobo");
            if (other.gameObject.tag == "Oni")
            {
                health -= 30;
                lifeBar.setHealth(health);
                KnockBack();

            }
            else if (other.gameObject.tag == "RedOni")
            {
                health -= 35;
                lifeBar.setHealth(health);
                KnockBack();
            }
            else
            {
                health -= 15;
                lifeBar.setHealth(health);
                KnockBack();
            }
           
        }
    }

    void KnockBack() {
      //play the animation of hurting
        if (inputSpeed < 0)
        {
             rb.AddForce(new Vector2(-knockbackForce, knockbackForce));
        }
        else if (inputSpeed > 0 )
        {
            rb.AddForce(new Vector2(-knockbackForce, knockbackForce));
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
  }

  void dead() {
    if(health <= 0) {
      SceneManager.LoadScene("EndGameScene");
    }
  }
    
}
