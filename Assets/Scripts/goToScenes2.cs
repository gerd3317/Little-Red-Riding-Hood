using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToScenes2 : MonoBehaviour
{
   // Start is called before the first frame update
   void Start()
   {

   }


   // Update is called once per frame
   void Update()
   {
      if (Input.anyKeyDown)
      {
         if (Application.loadedLevel == 1)
            Application.LoadLevel(2);
         else
            Application.LoadLevel(1);
      }
   }
}

