using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
   public GameObject theProjectile;
   public float shootTime;
   public Transform shootFrom;
   public int chanceShoot;

   float nextShootTime;
   Animator treeElfAnim;


    // Start is called before the first frame update
    void Start()
    {
      treeElfAnim = GetComponentInChildren<Animator>();
      nextShootTime = 0f; 
    }

    // Update is called once per frame

void OnTriggerStay2D(Collider2D other)
{if (theProjectile != null)
         if (other.tag == "Player" && nextShootTime < Time.time)
      {
         
               nextShootTime = Time.time + shootTime;
            if (Random.Range(0, 10) >= chanceShoot)
            {
               Instantiate(theProjectile, shootFrom.position, Quaternion.identity);

               treeElfAnim.SetTrigger("ShootToPlayer");
            }
         }
      }
      }
