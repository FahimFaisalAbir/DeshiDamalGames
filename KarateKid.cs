using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateKid : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
     void Update()
    {
       
        
    }

  private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.tag=="Flipping"){
        spriteRenderer.flipX=true;
  }
  }
}


