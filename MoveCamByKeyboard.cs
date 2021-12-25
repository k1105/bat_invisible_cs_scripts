using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamByKeyboard : MonoBehaviour
{
    Vector3 delta;
    Vector3 theta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        Vector3 currentPos = this.transform.position;
        delta = new Vector3(0.0f, 0.0f, 0.0f);
        theta = new Vector3(0.0f, 0.0f, 0.0f);
         // 左を向く
        if (Input.GetKey (KeyCode.LeftArrow)) {
            theta.y = -1.0f;
        }
        // 右を向く
        if (Input.GetKey (KeyCode.RightArrow)) {
            theta.y = 1.0f;
        }
        // 上を向く
        if (Input.GetKey (KeyCode.UpArrow)) {
            theta.x = -1.0f;
        }
        // 下を向く
        if (Input.GetKey (KeyCode.DownArrow)) {
            theta.x = 1.0f;
        }

        // 正面に移動
        if (Input.GetKey(KeyCode.LeftShift)) {
            delta = this.transform.forward * 0.05f;
        }

        // 後方に移動
        if (Input.GetKey(KeyCode.RightShift)) {
            delta = -this.transform.forward * 0.1f;
        }

        RaycastHit wallHit;


            this.transform.position += delta;
            this.transform.eulerAngles += theta;



}
 
}