using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portals : MonoBehaviour {
  public string sceneName;

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      SceneManager.LoadScene(sceneName);
    }
  }
}
