using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPortal : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Tanuki")
        {
            SceneManager.LoadScene("caveTanuki");
           
        }
        if (other.gameObject.tag == "TanukiBack")
        {
            SceneManager.LoadScene("MainCave");
            print("hahah");   
        }
        if (other.gameObject.tag == "Lava")
        {
            SceneManager.LoadScene("caveLava");
        }
        if (other.gameObject.tag == "Tanuki")
        {
            SceneManager.LoadScene("caveTanuki");
        }
        if (other.gameObject.tag == "Store")
        {
            SceneManager.LoadScene("Store");
        }
        if (other.gameObject.tag == "BigSkeleton")
        {
            SceneManager.LoadScene("skeletonScene");
        }
    }

   
}
