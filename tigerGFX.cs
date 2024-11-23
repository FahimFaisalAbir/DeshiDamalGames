using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class tigerGFX : MonoBehaviour
{
   
    public AIPath aiPath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x<=0.01f){//right
            transform.localScale=new Vector3(2f,2f,1f);
        }
        else if(aiPath.desiredVelocity.x>=0.01f){//left
            transform.localScale=new Vector3(-2f,2f,1f);
        }
        
    }
}
