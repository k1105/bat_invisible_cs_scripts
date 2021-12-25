using UnityEngine;
using System.Collections.Generic;

public class MultiEcholocationController : MonoBehaviour
{
    //private static readonly int Center = Shader.PropertyToID("_Center");
    //private static readonly int Radius = Shader.PropertyToID("_Radius");

    // ここにインスペクター上でEcholocationマテリアルをセットしておく

    // 半径が大きくなるスピード
    [SerializeField][Min(0.0f)] private float speed = 5.0f;

    // 現在の半径
    private Vector4[] centers = new Vector4[50];
    private float[] radiuses = new float[50];
    private int circle_num = 0;
    private int tail = 0;

    private float[] volumes = new float[50];

    // 毎フレーム半径のセットおよび拡張を行う
    private void Update()
    {
        Shader.SetGlobalFloatArray("GlobalRadiuses", radiuses);
        for(int i=0; i<circle_num; i++) {
            radiuses[i] += speed * Time.deltaTime;
        }

    }

    // 他のスクリプトからEmitCallを実行することで
    // 中心点を設定し、半径を0にリセットする
    public void EmitCall(Vector3 position, float volume)
    {
        radiuses[tail] = 0.0f;
        volumes[tail] = volume;
        Shader.SetGlobalFloatArray("GlobalVolumes", volumes);
        centers[tail] = position;
        Shader.SetGlobalVectorArray("GlobalCenters", centers);
        if (circle_num < 50) {
            circle_num++;
        }
        Shader.SetGlobalInt("GlobalCircleNum", circle_num);
        // 末尾のindex更新
        tail = (tail + 1) % 50;
    }
}