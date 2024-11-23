using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    // Start is called before the first frame update
    public float healthAmount;//gain health
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
          characterHealth theHealth=other.gameObject.GetComponent<characterHealth>();
          theHealth.addHealth(healthAmount);

          Destroy(gameObject);
        }

    }
}
