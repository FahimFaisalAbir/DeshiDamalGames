using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class characterHealth : MonoBehaviour
{
    //public restartGame theGameManager;

    //audio
     //public AudioClip playerHurt;
     //AudioSource playerAS;
     
    //
   ///
   /*public Text gameOverScreen;
   public Text gameWinScreen;*/
    public Slider healthSlider;
    public Image damageScreen;
    public Image over;

    bool damaged;
    Color damagedColor=new Color(0f,0f,0f,0.5f);
    float smoothColor=5f;
    //

public bool dead;
  
   //normal var
    public float fullHealth;
    
    float currentHealth;
    //playerController controlMovement;
    public GameObject deathFX;
  
    

  
    void Start()
    {
      currentHealth=fullHealth;
     
      //controlMovement=GetComponent<playerController>();

      //playerAS=GetComponent<AudioSource>();

      ///HUD

      healthSlider.maxValue=fullHealth;
      healthSlider.value=fullHealth;

      damaged=false;
      
    }

    // Update is called once per frame
    void Update()
    {
        if(damaged){
            

         damageScreen.color=damagedColor;
        }
        else{
            damageScreen.color=Color.Lerp(damageScreen.color,Color.clear,smoothColor*Time.deltaTime);
        }
        damaged=false;
        
    }

    public void addDamage(float damage){
        if(damage<=0){
            return;
        }
       
       //playerAS.clip=playerHurt;
       //playerAS.Play();
       //playerAS.PlayOneShot(playerHurt);

       currentHealth-=damage;
       healthSlider.value=currentHealth;

        

       damaged=true;
       
       if(currentHealth<=0){
           Animator gameOverAnimator=over.GetComponent<Animator>();
       gameOverAnimator.SetTrigger("over");
           makeDead();
       }

    
    }
    public void addHealth(float healthAmount){
        currentHealth+=healthAmount;
        healthSlider.value=currentHealth;
        if(currentHealth>fullHealth){
            currentHealth=fullHealth;
        }
       

    }
    
    public void makeDead(){
      
       
      Instantiate(deathFX,transform.position,transform.rotation);
       Destroy(gameObject);
       dead=true;
       
        //Animator gameOverAnimator=gameOverScreen.GetComponent<Animator>();
      // gameOverAnimator.SetTrigger("gameOver");
       damageScreen.color=damagedColor;

       SceneManager.LoadScene("PauseMenu");
      
      // theGameManager.restartTheGame();
    }

    public void winGame(){
        /*Animator winGameAnimator=gameWinScreen.GetComponent<Animator>();
     winGameAnimator.SetTrigger("gameOver");
     Destroy(gameObject);
     theGameManager.restartTheGame();*/
     
    }
}
