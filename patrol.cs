using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : enemy
{
    public GameObject explosionEffect;
    public GameObject blastEffect;
    public GameObject bullet;
    public float fireRate;
    public Transform shotSpawner;
    private float nextFire=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();


        if(targetDistance<0){
            if(facingRight){
                Flip();
            }
        }
        else{
            if(!facingRight){
                Flip();
            }
        }

        if((targetDistance)<attackDistance && Time.time>nextFire){
            Anim.SetTrigger("Shooting");
            nextFire=Time.time+fireRate;
            //Shooting();
            Shooting();

        }
    }


    public void Shooting(){
        GameObject tempBullet=Instantiate(bullet,shotSpawner.position,shotSpawner.rotation);
         if(!facingRight){
            tempBullet.transform.eulerAngles=new Vector3(0,0,180);
         }
    }

    
}
