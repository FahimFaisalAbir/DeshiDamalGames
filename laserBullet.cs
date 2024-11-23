using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserBullet : MonoBehaviour
{
   public GameObject burstEffect;
    private Transform player;
    public float speed;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
      player=GameObject.FindGameObjectWithTag("Player").transform;

      target=new Vector2(player.position.x,player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);
        
        if(transform.position.x==target.x && transform.position.y==target.y){
            DesrtroyProjectile();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            DesrtroyProjectile();
            characterHealth hurtEnemy=other.gameObject.GetComponent<characterHealth>();
             hurtEnemy.addDamage(5);
        }
    }

    void DesrtroyProjectile(){
        Instantiate(burstEffect,transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
