using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuResponsividade : MonoBehaviour
{
    public int index = 3;
    public KeyCode up,down, enter, esc;
    public string sceneName;

    [Header("buttons")]
    public Image cont,opt, cred, exit;

    [Header("setores")]
    public GameObject opSec, credSec, mainMenu;

    void Start()
    {
        opSec.SetActive(false);
        credSec.SetActive(false);
        mainMenu.SetActive(true);

        cont.color = new Color32(255,255,225,255);
        opt.color = new Color32(255,255,225,150);
        cred.color = new Color32(255,255,225,150);
        exit.color = new Color32(255,255,225,150);
    }
    void Update()
    {
        if(Input.GetKeyDown(up)) {
            if (index< 3)
            {
                index++;
            }
            else {
                index -= 3;
            }
        }

        if (Input.GetKeyDown(down))
        {
            if (index > 0)
            {
                index--;
            }
            else{
                index += 3;
            }
        }
        print(index);
        Selected(sceneName);
    }

    public void Selected (string gameScene) {
        if (index == 3)
        {
            cont.color = new Color32(255,255,225,255);
            opt.color = new Color32(255,255,225,150);
            cred.color = new Color32(255,255,225,150);
            exit.color = new Color32(255,255,225,150);

            if (Input.GetKeyDown(enter))
            {
                SceneManager.LoadScene(gameScene);
            }
        }
        else if (index == 2) 
        {
            cont.color = new Color32(255,255,225,150);
            opt.color = new Color32(255,255,225,255);
            cred.color = new Color32(255,255,225,150);
            exit.color = new Color32(255,255,225,150);

            if (Input.GetKeyDown(esc))
            {
                opSec.SetActive(false);
                credSec.SetActive(false);
                mainMenu.SetActive(true);
            }

             if (Input.GetKeyDown(enter))
            {
                opSec.SetActive(true);
                credSec.SetActive(false);
                mainMenu.SetActive(false);
            }
        }
        else if (index == 1) 
        {
            cont.color = new Color32(255,255,225,150);
            opt.color = new Color32(255,255,225,150);
            cred.color = new Color32(255,255,225,255);
            exit.color = new Color32(255,255,225,150);
            if (Input.GetKeyDown(esc))
            {
                opSec.SetActive(false);
                credSec.SetActive(false);
                mainMenu.SetActive(true);
            }

             if (Input.GetKeyDown(enter))
            {
                opSec.SetActive(false);
                credSec.SetActive(true);
                mainMenu.SetActive(false);
            }
        }
        else if (index == 0) 
        {
            cont.color = new Color32(255,255,225,150);
            opt.color = new Color32(255,255,225,150);
            cred.color = new Color32(255,255,225,150);
            exit.color = new Color32(255,255,225,255);

             if (Input.GetKeyDown(enter))
            {
                 Application.Quit();
            }
        }

    }
}
