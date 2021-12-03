using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    // Start is called before the first frame update
    protected static List<Vector3> posList;
    public GameObject player = null;
    protected static string txt;
    void Start()
    {  
        if (player == null) {
            Debug.Log("playerがセットされていません");
        }
        posList = new List<Vector3>();
        posList.Add(player.transform.position);   
        Invoke("ChangeScene", 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        posList.Add(player.transform.position);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene02");
    }

    public static List<Vector3> GetPosList() {
        return posList;
    }
}
