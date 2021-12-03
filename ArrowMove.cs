using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ArrowMove : MonoBehaviour
/// <summary>
/// UI上の矢印の向きをカメラの動きに合わせて回転させる. 
/// 使用する際は, 回転させたい画像にこのスクリプトをアタッチし, 同時に動きを追従したいオブジェクトをinspectorからtargetに指定する.
/// </summary>
{
    public GameObject target = null;
    private Vector3 theta;

    void Start() {
        if (target == null) {
            Debug.Log("targetがセットされていません. inspector上でtargetに運動を追従したいオブジェクトを設定してください. ");
        }
    }
 
    void Update()
    {   
        theta = new Vector3(0.0f, 0.0f, 0.0f);
        theta.z = -target.transform.eulerAngles.y;
        this.transform.eulerAngles = theta;
        }
}