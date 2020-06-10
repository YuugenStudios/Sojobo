using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EskeletonScript : MonoBehaviour
{
  [Header("Face")]
  public Transform eskeleton;
  bool attacking = false;
  public float faceWaitTime;
  bool turn = true;
  public bool left;

  [Header("Shoot")]
  public GameObject bone;
  GameObject newBone;
  public Animator anim;
  public Transform boneShooter;
  public LayerMask playerMask;
  public float shootWaitTime, raycastDistance;
  float nextShoot;
  RaycastHit2D hit;

  void Start() {
    Physics2D.queriesStartInColliders = false;
  }

  void Update() {
    /*if (!attacking && turn) {
      StartCoroutine(changeLookDirection(faceWaitTime));
    }*/

    if (left) {
      hit = Physics2D.Raycast(transform.position, -transform.right, raycastDistance, playerMask);
    } else {
      hit = Physics2D.Raycast(transform.position, transform.right, raycastDistance, playerMask);
    }

    if (hit.collider != null) {
      if (hit.collider.CompareTag("Player") && Time.time >= nextShoot) {
        anim.SetTrigger("Shoot");
        Instantiate(bone, boneShooter.position, Quaternion.identity);
        nextShoot = Time.time + shootWaitTime;
      }
    }
  }

  IEnumerator changeLookDirection(float WT) {
    turn = false;
    eskeleton.localScale = new Vector3(-eskeleton.localScale.x, eskeleton.localScale.y, eskeleton.localScale.y);

    if (left) {
      left = false;
    } else {
      left = true;
    }

    yield return new WaitForSeconds(WT);

    turn = true;
  }
}
