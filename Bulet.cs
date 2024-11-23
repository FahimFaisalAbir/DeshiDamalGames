using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    public float speed;
    public int damage=1;

    Rigidbody2D myRb;


    // Start is called before the first frame update
    void Start()
    {
        myRb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        enemy otherEnemy=other.GetComponent<enemy>(); 
        if(otherEnemy!=null){
            otherEnemy.TookDamage(damage);
        }

        //Destroy(gameObject);
    }
    public void removeForce(){
        myRb.velocity=new Vector2(0,0);
    }
}
