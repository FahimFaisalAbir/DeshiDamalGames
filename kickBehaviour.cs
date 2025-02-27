﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kickBehaviour : StateMachineBehaviour
{
    public float timer;
    public float minTime;
    public float maxTime;
    //public float speed;

    private Transform playerPos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        timer=Random.Range(minTime,maxTime);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     if(timer<=0){
         animator.SetTrigger("idle");
     }
     else{
         timer-=Time.deltaTime;
     }   
    
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
