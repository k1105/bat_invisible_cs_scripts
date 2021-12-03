using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateObject : MonoBehaviour
{
    private GameObject obj;
    private Vector3 theta;
    // Start is called before the first frame update
    void Start()
    {
        obj = this.gameObject;
        theta = obj.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        theta.y++;
        obj.transform.eulerAngles  = theta;
    }
}
