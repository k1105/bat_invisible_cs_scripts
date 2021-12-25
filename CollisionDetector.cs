using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionDetector : MonoBehaviour
{
    public GameObject hitInfo = null;
    public GameObject player = null;
    public GameObject opponent = null;
    // Start is called before the first frame update
    private Vector3 prevPos;
    private Vector3 currentPos;
    void Start()
    {
        if(player == null) {
            Debug.Log("playerがセットされていません");
        }

        if (opponent == null) {
            Debug.Log("opponentがセットされていません");
        }

        prevPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = player.transform.position;
        Vector3 delta = currentPos - prevPos;
        
        RaycastHit wallHit;

        if ( Physics.SphereCast(currentPos, 0.1f, delta, out wallHit, 0.5f) || (Physics.SphereCast(currentPos, 0.1f, -delta, out wallHit, 0.5f))) {
            if (wallHit.collider.name == opponent.name) {
                // 衝突時に呼び出す任意の関数をここに記述
                // Debug.Log(opponent.name + "に衝突しました");
                Text info_text = hitInfo.GetComponent<Text> ();
                // テキストの表示を入れ替える
                info_text.text = opponent.name + "に衝突しました";
            }
        }

        prevPos = currentPos;
    }
}