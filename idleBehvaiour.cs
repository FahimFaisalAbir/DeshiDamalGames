﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehvaiour : StateMachineBehaviour
{
    
    public float speed;
    public float timer;
    public float minTime;
    public float maxTime;
    private Transform playerPos;

   
    private int rand;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex){
    
        timer=Random.Range(minTime,maxTime);
        playerPos=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     if(timer<=0){
         
        rand=Random.Range(0,11);
        
        if(rand>=7){
            animator.SetTrigger("Kick");
        }
        else {
            animator.SetTrigger("Punch");
        }
         
     }
     else{
         timer-=Time.deltaTime;
     } 
      Vector2 target=new Vector2(playerPos.position.x,animator.transform.position.y);
     animator.transform.position=Vector2.MoveTowards(animator.transform.position,target,speed*Time.deltaTime);  
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
