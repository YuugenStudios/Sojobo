using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class optionsResponsividade : MonoBehaviour
{
    public int index = 2;
    public KeyCode right,left,esc;

    [Header("buttons")]
    public Image cont, video, audio;

    [Header("setores")]
    public GameObject mainMenu;

    void Start()
    {       
        cont.color = new Color32(255,255,255,255);
        video.color = new Color32(255,255,255,150);
        audio.color = new Color32(255,255,255,150);
    }

    void Update()
    {
        if(Input.GetKeyDown(right)) {
            if (index < 3)
            {
                index--;
            }
            else {
                index -= 2;
            }
        }

        if (Input.GetKeyDown(left))
        {
            if (index > -1)
            {
                index++;
            }
            else{
                index += 2;
            }
        }
      //print(index);
        Selected();
    }

    void Selected (){
      if(index == 2) {
            cont.color = new Color32(255,255,225,255);
            video.color = new Color32(255,255,225,150);
            audio.color = new Color32(255,255,225,150);
      }
      else if(index==1){ 

            cont.color = new Color32(255,255,225,150);
            video.color = new Color32(255,255,225,255);
            audio.color = new Color32(255,255,225,150);
      }

      else if(index==0){ 
        
            cont.color = new Color32(255,255,225,150);
            video.color = new Color32(255,255,225,150);
            audio.color = new Color32(255,255,225,255);
      }
    

    }


}
