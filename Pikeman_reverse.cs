using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pikeman_reverse : enemy
{
    public float walkDistance;

    private bool walk1;
    private bool attack1=false;
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
        

        Anim.SetBool("Walk",walk1);
        Anim.SetBool("Attack",attack1);

        if(Mathf.Abs(targetDistance)<walkDistance){
            walk1=true;

        }

        if(Mathf.Abs(targetDistance)<attackDistance){
            attack1=true;
            walk1=false;
        }
        
    }

  private void FixedUpdate() {

     if(walk1 && !attack1){
         if(targetDistance<0){
             rb2d.velocity=new Vector2(speed,rb2d.velocity.y);
             if(!facingRight){
                 Flip();
             }
         }
         else{
             rb2d.velocity=new Vector2(-speed,rb2d.velocity.y);
            if(facingRight){
                Flip();
            }
         }
     } 
    }

    public void ResetAttack(){
   attack1=false;
    }
}


