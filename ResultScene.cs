using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public GameObject mirror = null;
    private List<Vector3> posList = new List<Vector3>();
    // Start is called before the first frame update
    private int iCnt = 0;
    void Start()
    {
        posList = GameScene.GetPosList();
        Debug.Log(posList.Count);
        Invoke("ChangeScene", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (iCnt < posList.Count) {
            mirror.transform.position = posList[iCnt];
            iCnt++;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene01");
    }
}
