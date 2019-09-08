using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
   public float enemyMaxHealth;
   public bool drops;
   public GameObject theDrops;
   float currentHealth;
   SpriteRenderer sr;//player be hurt and change color

   // Start is called before the first frame update
   void Start()
    {
      currentHealth = enemyMaxHealth;
      sr = GetComponent<SpriteRenderer>();

   }

    // Update is called once per frame
    void Update()
    {
      sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 1f);//player be hurt and change color
   }
   public void addDamage(float damage)
   {
      sr.color = new Color(0, 0, 0);//player be hurt and change color
      currentHealth -= damage;
      if (currentHealth<=0)
      {
         makeDead();
      }
   }
   public void makeDead()
   { if (gameObject != null)
      {
         Destroy(gameObject.transform.parent.gameObject);
      }
      if (drops) Instantiate(theDrops, transform.position, transform.rotation);

   }
}
