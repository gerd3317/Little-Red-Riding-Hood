using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour{
   public Transform target; //what camera is following
   public float smoothing; //dampeing effect

   Vector3 offsets;
   float lowY;

    // Start is called before the first frame update
    void Start()
    {
      offsets = transform.position - target.position;

      lowY = transform.position.y;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if (target != null)
      {
         Vector3 targetCanPos = target.position + offsets;
         transform.position = Vector3.Lerp(transform.position, targetCanPos, smoothing * Time.deltaTime);
         if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
      }
    }
}
