using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ArrowMove : MonoBehaviour
{
    Camera mainCam;
    Vector3 theta;

    void Start() {
        mainCam = Camera.main;
    }
 
    void Update()
    {   
        theta = new Vector3(0.0f, 0.0f, 0.0f);
        theta.z = mainCam.transform.eulerAngles.y;
        this.transform.eulerAngles = theta;
        }
}