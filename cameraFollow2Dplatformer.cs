using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2Dplatformer : MonoBehaviour
{
    public Transform target; //what the camera is following gameobjecct.transform.pos
    public float smoothing;//dampening effect or easing off the camera
    Vector3 offset;//the difference between character and camera
    float lowY;//the lowest point our camera can go
    //when char falls of the screen our camera will follow


    // Start is called before the first frame update
    void Start()
    {
       //at first calc offset
       offset=transform.position-target.position;
       lowY=transform.position.y;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //add an aim pos based on position
        //where the camera wants to be

        Vector3 targetCamPos=target.position+offset;
        //ability to slowly transform to that pos
        //Lerp allows to slowly move the position
        //delta time is the difference between time now and the last frame
        transform.position=Vector3.Lerp(transform.position,targetCamPos,smoothing*Time.deltaTime);
        //line to prevent camera from following falling char
        if(transform.position.y<lowY){
            transform.position=new Vector3(transform.position.x,lowY,transform.position.z);
        }
    }
}
