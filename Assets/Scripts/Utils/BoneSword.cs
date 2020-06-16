using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoneSword : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
          PlayerBehaviour.hasBoneSword = true;
          Destroy(this.gameObject);
          SceneManager.LoadScene("MainCave 2");
        }
    }
}
