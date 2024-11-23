using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public float damage;
    public float damageRate;//how often enemy can do damage so that char doesnt die

    public float pushBackForce;


    float nextDamage;//next when it occurrs

    // Start is called before the first frame update
    void Start()
    {
     nextDamage=0f;//char damaged immediately   
     //Time.time

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.tag=="Player" && nextDamage<Time.time){
            //Time.time=now
            characterHealth theplayerHealth=other.gameObject.GetComponent<characterHealth>();
            theplayerHealth.addDamage(damage);
            nextDamage=Time.time+damageRate;
            //give us time gap between damage

            pushBack(other.transform);

        }
    }

    void pushBack(Transform pushedObject){
        Vector2 pushDirection=new Vector2(0,(pushedObject.position.y-transform.position.y)).normalized;
        //only pushing upper
        //vector direction's Y is opposite of the enemy
        pushDirection*=pushBackForce;
        Rigidbody2D pushRB=pushedObject.gameObject.GetComponent<Rigidbody2D>();
        pushRB.velocity=Vector2.zero;//x=0,y=0
        pushRB.AddForce(pushDirection,ForceMode2D.Impulse);


    }
}

