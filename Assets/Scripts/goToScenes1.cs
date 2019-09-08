using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToScenes1 : MonoBehaviour {

   public float passScreen;
   float passTime;

 // Start is called before the first frame update
   void Start()
   {
      passTime = Time.time + passScreen;
   }


   // Update is called once per frame
   void Update()
   {
      if (passTime <= Time.time)
      {

         if (Application.loadedLevel == 0)
            Application.LoadLevel(1);
         else
            Application.LoadLevel(0);
      }
   }
}




