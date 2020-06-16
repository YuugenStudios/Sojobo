using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuResponsividade : MonoBehaviour
{
    public int index = 1;
    public KeyCode up,down, enter, esc;
    public string sceneName;

    [Header("buttons")]
    public Image cont,exit;

    void Start()
    {

        cont.color = new Color32(255,255,225,255);
        exit.color = new Color32(255,255,225,150);
    }
    void Update()
    {
        if(Input.GetKeyDown(up)) {
            if (index< 1)
            {
                index++;
            }
            else {
                index -= 1;
            }
        }

        if (Input.GetKeyDown(down))
        {
            if (index > 0)
            {
                index--;
            }
            else{
                index ++;
            }
        }
        print(index);
        Selected(sceneName);
    }

    public void Selected (string gameScene) {
        if (index == 1)
        {
            cont.color = new Color32(255,255,225,255);
            exit.color = new Color32(255,255,225,150);

            if (Input.GetKeyDown(enter))
            {
                SceneManager.LoadScene(gameScene);
            }
        }
        else if (index == 0) 
        {
            cont.color = new Color32(255,255,225,150);
            exit.color = new Color32(255,255,225,255);

             if (Input.GetKeyDown(enter))
            {
                 Application.Quit();
            }
        }

    }
}
