using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerMovement : MonoBehaviour
{
    //
    public Transform gunTip;

   public float fireRate=0.5f;//one rocket ever half a second
   float nextFire;//fire next immediately
   public GameObject bullet;
    //
 
    bool crouch=false;
    
    public CharacterController2D controller;
    float HorizontalMove=0f;
    public float runSpeed=40f;
    Animator Animator;
    bool jump=false;
    // Start is called before the first frame update
    void Start()
    {
        Animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
        HorizontalMove=Input.GetAxisRaw("Horizontal")*runSpeed;
        //HorizontalMove=CrossPlatformInputManager.GetAxis("Horizontal")*runSpeed;
        Animator.SetFloat("Speed",Mathf.Abs(HorizontalMove));   
      //-1<x<1
     //  
      //if(CrossPlatformInputManager.GetButtonDown("Jump")){
            if (Input.GetButtonDown("Jump")) { 
            jump=true;
            //Animator.SetBool("isJumping",true);
      }
      
      //if(CrossPlatformInputManager.GetButtonDown("Crouch")){
            if (Input.GetButtonDown("Crouch"))
            {

                crouch =true;
      }else if(Input.GetButtonUp("Crouch"))
            {
            crouch =false;
      }

       //if((CrossPlatformInputManager.GetButtonDown("Fire1")) && Time.time>nextFire){
                if(Input.GetButtonDown("Fire1") && Time.time>nextFire){
               
               
                nextFire=Time.time+fireRate;
                
                Animator.SetTrigger("Shoot");
                 GameObject  tempBullet=Instantiate(bullet,gunTip.position,gunTip.rotation);
                
           
                
                //fireBullet();

            }
            if(Input.GetButtonDown("Fire2") ){
                
            
             }

    
    }
    public void ResetFire(){
 //Animator.SetTrigger("Shoot");
    }

    private void FixedUpdate() {
        controller.Move(HorizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump=false;
        //Animator.SetBool("Jump",false);
        
        
        
        //crouch,jump
    }
    
    public void OnLanding(){
        //Animator.SetBool("isJumping",false);
    }
    public void OnCrouching(bool isCrouching){
       // Animator.SetBool("isCrouching",isCrouching);


    }
}
