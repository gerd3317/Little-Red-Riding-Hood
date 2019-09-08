using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
   public float fullHealth;
   public GameObject death;
   public AudioClip playerHurt; //audio
   public restartGame theGameManager;
   public static float currentHealth;
   private PlayerController controlMovement;

   AudioSource playerAS; //audio

   //HUD Variables
   public Slider healthSlider;
   public Image damageScreen;
   public Text GameOverScreen;
   SpriteRenderer sr;//player be hurt and change color

   bool damaged = false;
   Color damageColor = new Color(2f,86f,58f,10.3f);
   float smoothColor = 1;

   // Start is called before the first frame update
   public void Start()
   {
      currentHealth = fullHealth;
      controlMovement = GetComponent<PlayerController>();
      //HUD Initilization
      NewMethod();
      healthSlider.value = fullHealth;

      damaged = false;

      playerAS = GetComponent<AudioSource>();//audio
      sr = GetComponent<SpriteRenderer>();//player be hurt and change color
   }

   private void NewMethod()
   {
      healthSlider.maxValue = fullHealth;
   }


   // Update is called once per frame
   void Update()
   {
      if (damaged)
      {
         damageScreen.color = damageColor;
      }
      else
      {
         damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor*Time.deltaTime);
         sr.color = Color.Lerp(sr.color, Color.white, Time.deltaTime / 1f);//player be hurt and change color
      }
      damaged = false;
   }
   public void addDamage(float damage)
   {
      if (damage <= 0) return;
      currentHealth -= damage;

      playerAS.clip = playerHurt;//audio
      NewMethod1();
      sr.color = new Color(0, 0, 0);//player be hurt and change color

      healthSlider.value = currentHealth;
      damaged = true;
      if (currentHealth <= 0)
      {
         makeDead();
      }
   }

   private void NewMethod1()
   {
      playerAS.Play();
   }

   public void addHealth(float healthAmount)
   {
      currentHealth += healthAmount;
      if (currentHealth > fullHealth) currentHealth = fullHealth;
      healthSlider.value = currentHealth;
   }

   public void makeDead()
   {
      Instantiate(death, transform.position, transform.rotation);
      damageScreen.color = damageColor;
      Animator gmaeOverAnim = GameOverScreen.GetComponent<Animator>();
      gmaeOverAnim.SetTrigger("gameOver");
      if (gameObject != null)
      {
         Destroy(gameObject);
      }
      theGameManager.restartTheGame();
   }

   public override bool Equals(object obj)
   {
      var health = obj as PlayerHealth;
      return health != null &&
             base.Equals(obj) &&
             EqualityComparer<PlayerController>.Default.Equals(controlMovement, health.controlMovement);
   }

   public override int GetHashCode()
   {
      return base.GetHashCode();
   }

   public override string ToString()
   {
      return base.ToString();
   }
}
