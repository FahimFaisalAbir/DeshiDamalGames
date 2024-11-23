using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyhealth : MonoBehaviour
{
    public GameObject die;
    public float enemyMaxhealth;

    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth=enemyMaxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addDamage(float damage){
      currentHealth-=damage;
      if(currentHealth<=0){
          makeDead();
      }

      void makeDead(){
          Instantiate(die,transform.position,transform.rotation);
          Destroy(gameObject);
      }
    }
}
