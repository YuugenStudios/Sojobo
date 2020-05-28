using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject mapCanvas;
    bool paused = false;
    float normalScale;

    private void Start()
    {
        print(Time.timeScale);
        normalScale = Time.timeScale;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab) && !paused) {
            Time.timeScale = 0;
            mapCanvas.SetActive(true);
            paused = true;
        } else if (Input.GetKeyDown(KeyCode.Tab) && paused) {
            Time.timeScale = normalScale;
            mapCanvas.SetActive(false);
            paused = false;
        }
    }
}
