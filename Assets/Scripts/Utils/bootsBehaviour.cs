using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bootsBehaviour : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
          Destroy(this.gameObject);
            PlayerBehaviour.calcado = true;
        }
    }
}
