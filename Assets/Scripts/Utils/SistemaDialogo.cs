using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SistemaDialogo : MonoBehaviour
{

    public TextMeshProUGUI textDisplay;
    public string[] frases;
    private int index;
    private float textoVelocidade = 0.03f;
    //public GameObject btnNext;
    public GameObject player;
    public GameObject inimigo;
    public GameObject barra;
    public string PlayerBehaviour;
    public string FinalBoss;

    //public LayerMask DialogLayer;






    void Start()
    {
        (player.GetComponent(PlayerBehaviour) as MonoBehaviour).enabled = false;
        (inimigo.GetComponent(FinalBoss) as MonoBehaviour).enabled = false;
        barra.SetActive(true);

        StartCoroutine(texto());

    }
    void Update()
    {

       // RaycastHit2D ray = Physics2D.Raycast(player.transform.position, Vector2.right, 6, DialogLayer);
        //RaycastHit2D ray2 = Physics2D.Raycast(player.transform.position, Vector2.left, 6, DialogLayer);
       // if (ray || ray2)
        //{
            if (textDisplay.text == frases[index]&& Input.GetButtonDown("Jump"))
            {
               ProximaFrase();
            }

       // }

       
        
    }
    IEnumerator texto()
    {
        foreach (char letter in frases[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(textoVelocidade);
        }
    }

    public void ProximaFrase()
    {
        //btnNext.SetActive(false);

        if (index < frases.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(texto());
        }

        else
        {
            textDisplay.text = "";
           // btnNext.SetActive(false);
            (player.GetComponent(PlayerBehaviour) as MonoBehaviour).enabled = true;
            (inimigo.GetComponent(FinalBoss) as MonoBehaviour).enabled = true;
            barra.SetActive(false);


        }
    }
}
