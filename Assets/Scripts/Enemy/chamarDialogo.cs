using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chamarDialogo : MonoBehaviour
{
    public LayerMask playerLayer;
    public GameObject dialogo;
    public string SistemaDialogo;

    void Start()
    {
        (dialogo.GetComponent(SistemaDialogo) as MonoBehaviour).enabled = false;

    }


    public void dialogoaa()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.right, 1, playerLayer);
        RaycastHit2D ray2 = Physics2D.Raycast(transform.position, Vector2.left, 1, playerLayer);

        if (ray||ray2)
        {

            (dialogo.GetComponent(SistemaDialogo) as MonoBehaviour).enabled = true;
        }
    }
}
