using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
   public float weaponDamage;
   projectilecontroller myPC;
   public GameObject explosionEffect;

   // Start is called before the first frame update
   void Awake()
   {
      myPC = GetComponentInParent<projectilecontroller>();
   }

   // Update is called once per frame
   void Update()
   {
   }
   void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
      {
         myPC.removeForce();
         Instantiate(explosionEffect, transform.position, transform.rotation);
         Destroy(gameObject);
         if (other.tag == "enemy")
         {
            enemyhealth hurtEnemy = other.gameObject.GetComponent<enemyhealth>();
            hurtEnemy.addDamage(weaponDamage);
         }
      }
   }

   void OnTriggerStay2D(Collider2D other)
   {
      if (other.gameObject.layer == LayerMask.NameToLayer("shootable"))
      {
         myPC.removeForce();
         Instantiate(explosionEffect, transform.position, transform.rotation);
         Destroy(gameObject);
         if (other.tag == "enemy")
         {
            enemyhealth hurtEnemy = other.gameObject.GetComponent<enemyhealth>();
            hurtEnemy.addDamage(weaponDamage);
         }
      }
   }
}
