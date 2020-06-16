using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class callTheEnd : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D other)
    {
        if(PlayerBehaviour.hasFlameSword) {
          Destroy(this.gameObject);
        }
    }
}
