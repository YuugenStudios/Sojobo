using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {
  public int lavaDamage;
  public float damageCooldown;
  float nextDamage = 0;

  private void OnTriggerStay2D(Collider2D other) {
    if (other.CompareTag("Player") && Time.time >= nextDamage && !PlayerBehaviour.calçado) {
      PlayerBehaviour.health -= lavaDamage;
      nextDamage = Time.time + damageCooldown;
    }
  }
}
