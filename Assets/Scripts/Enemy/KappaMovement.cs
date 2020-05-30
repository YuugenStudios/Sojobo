using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaMovement : MonoBehaviour
{
    public float speed = -20;
    public Rigidbody2D rb;

    [Header("Physics2D")]
    RaycastHit2D hit;
    RaycastHit2D hit2;
    public LayerMask obstaculos;
    public float distance;

    void Update()
    {
        hit = Physics2D.Raycast(transform.position, Vector2.right, distance, obstaculos);
        hit2 = Physics2D.Raycast(transform.position, Vector2.left, distance, obstaculos);

        if (hit2)
        {
            speed *= -1;
        }
        if (hit)
        {
            speed *= -1;
        }

        if (speed < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (speed > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position, Vector2.left * distance);
        Gizmos.DrawRay(transform.position, Vector2.right * distance);
    }
}
