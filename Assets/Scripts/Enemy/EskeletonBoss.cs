using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskeletonBoss : MonoBehaviour
{
    public Animator anim;
    public float cooldown;
    float nextPunch;

    void Update() {
        if (Time.time >= nextPunch) {
            anim.SetTrigger("Punch");
            nextPunch = Time.time + cooldown;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
           // FindObjectOfType<AudioManager>().Play("danoSojobo");
            print("dano no player :)");
        }
    }
}
