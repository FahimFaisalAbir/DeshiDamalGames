using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikeman : enemy
{
    public float walkDistance;

    private bool walk;
    private bool attack=false;
    Animator Anim;

    // Start is called before the first frame update
    void Start()
    {
        Anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        

        Anim.SetBool("Walk",walk);
        Anim.SetBool("Attack",attack);

        if(Mathf.Abs(targetDistance)<walkDistance){
            walk=true;

        }

        if(Mathf.Abs(targetDistance)<attackDistance){
            attack=true;
            walk=false;
        }
        
    }

  private void FixedUpdate() {

     if(walk && !attack){
         if(targetDistance<0){
             rb2d.velocity=new Vector2(speed,rb2d.velocity.y);
             if(facingRight){
                 Flip();
             }
         }
         else{
             rb2d.velocity=new Vector2(-speed,rb2d.velocity.y);
            if(!facingRight){
                Flip();
            }
         }
     } 
    }

    public void ResetAttack(){
   attack=false;
    }
}
