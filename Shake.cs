using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public Animator CamAnim;
    // Start is called before the first frame update
    public void CamShake(){
        CamAnim.SetTrigger("Shake");
    }
}
