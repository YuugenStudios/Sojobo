using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class endGame : MonoBehaviour
{
    public string sceneName;
    public void Update()
    {
        callScene();
    }

    public void callScene() {
      if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
