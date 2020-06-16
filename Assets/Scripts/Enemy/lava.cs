using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
  public int lavaDamage;
  public float damageCooldown;
  float nextDamage = 0;

  private void OnTriggerStay2D(Collider2D other) {
    if (other.CompareTag("Player") && Time.time >= nextDamage && !PlayerBehaviour.calcado) {
      PlayerBehaviour.health -= lavaDamage;
      nextDamage = Time.time + damageCooldown;
    }
  }

  void Update()
  {
      if(PlayerBehaviour.calcado) {
        GetComponent<BoxCollider2D>().isTrigger = false;
      }
  }
}
