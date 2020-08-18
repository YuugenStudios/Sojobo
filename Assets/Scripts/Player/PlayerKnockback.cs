using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    public PlayerBehaviour player;
    
    public IEnumerator Knockback (float duration, float range, UnityEngine.Vector2 dir) {
    float timer = 0;

    while(duration > timer) {
      timer += Time.deltaTime;

      player.rb.AddForce(new Vector2(dir.x * -range, dir.y * -range));
    }
    yield return 0;
  }
}
