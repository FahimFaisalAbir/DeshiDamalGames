using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{

    private Shake shake;

    public timeManager TimeManager;
   // private Shake shake;
    public float weaponDamage;
    Bulet myPc;
    //public cameraFollow cameraShake;

    //private Shake shake;
 
    public GameObject explosionEffect;
     public GameObject blastEffect;

     
     
    // Start is called before the first frame update
    void Start()
    {
        shake=GameObject.FindGameObjectWithTag("ScreenShakwe").GetComponent<Shake>();
        //shake=GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        myPc=GetComponentInParent<Bulet>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer==LayerMask.NameToLayer("Shootable") && other.gameObject.layer!=LayerMask.NameToLayer("army")){
         myPc.removeForce();
         Instantiate(explosionEffect,transform.position,transform.rotation);
         Instantiate(blastEffect,transform.position,transform.rotation);
         //shake.CamShake();
         shake.CamShake();
         TimeManager.DoSlowmotion();
         
         
         Destroy(gameObject);
         if(other.tag=="Enemy" ){
             enemyhealth hurtEnemy=other.gameObject.GetComponent<enemyhealth>();
             hurtEnemy.addDamage(weaponDamage);
            
         }
         else if(other.tag=="EnemyWithHealth" ){
             
              enemy otherEnemy=other.GetComponent<enemy>();
             if(otherEnemy!=null){
             otherEnemy.TookDamage(5);
             }
         }
         else{
             
              enemyRev otherEnemy=other.GetComponent<enemyRev>();
             if(otherEnemy!=null){
             otherEnemy.TookDamage(5);
             }
         }
        }
 }
    
    

private void OnTriggerStay2D(Collider2D other) {

    if(other.gameObject.layer==LayerMask.NameToLayer("Shootable")){
         myPc.removeForce();
         Instantiate(explosionEffect,transform.position,transform.rotation);
         Instantiate(blastEffect,transform.position,transform.rotation);
         //shake.CamShake();
         //pushBack(other.transform);
         shake.CamShake();
         TimeManager.DoSlowmotion();
         
         Destroy(gameObject);
         if(other.tag=="Enemy" ){
             enemyhealth hurtEnemy=other.gameObject.GetComponent<enemyhealth>();
             hurtEnemy.addDamage(weaponDamage);
         }
         else if(other.tag=="EnemyWithHealth" ){
             
             
            enemy otherEnemy=other.GetComponent<enemy>();
             if(otherEnemy!=null){
             otherEnemy.TookDamage(5);
             }
         }
         else{
             
              enemyRev otherEnemy=other.GetComponent<enemyRev>();
             if(otherEnemy!=null){
             otherEnemy.TookDamage(5);
             }
         }
        }
    

}

void StartAnim()
    {
         //StartCoroutine(cameraShake.camShake(.45f,0.8f));
    }

    
    void pushBack(Transform pushedObject){
        Vector2 pushDirection=new Vector2((transform.position.x-pushedObject.position.x),(pushedObject.position.y-transform.position.y)).normalized;
        //only pushing upper
        //vector direction's Y is opposite of the enemy
        pushDirection*=5;
        Rigidbody2D pushRB=pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity=Vector2.zero;//x=0,y=0
        pushRB.AddForce(pushDirection,ForceMode2D.Impulse);


    }

  
}


