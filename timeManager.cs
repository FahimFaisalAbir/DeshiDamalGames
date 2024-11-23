using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeManager : MonoBehaviour
{
    public float slowdownFactor=0.7f;
    public float slowdownLength=2f;

    private void Update() {
      
    Time.timeScale+=(2f/slowdownLength)*Time.unscaledDeltaTime;  
    Time.timeScale=Mathf.Clamp(Time.timeScale,0f,1f);
    //slowly come back in 2s
    }

///if time scale is 1,running in real time 
    public void DoSlowmotion(){
      Time.timeScale=slowdownFactor;
      Time.fixedDeltaTime=Time.timeScale*.035f;
      //20% slower than normal
    }
}
