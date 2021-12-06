using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Scene04Manager : MonoBehaviour
{
    public GameObject mirror = null;
    public GameObject echolocationCountTextObject = null;
    private List<Vector3> posList = new List<Vector3>();
    // Start is called before the first frame update
    private int iCnt = 0;

    public GameObject buttonImageObject = null;
    public GameObject resultTextObject = null;
    public string[] timeupMessage = new string[7];
    private int windowState = 0;
    private Image buttonImage;
    private Text echolocationCountText;
    private Text resultText;
    private bool canSkip = false;
    // Start is called before the first frame update
    void Start () {
        if(mirror == null) {
            Debug.Log("mirrorがセットされていません");
        }
        if (buttonImageObject == null) {
            Debug.Log("buttonImageObjectがセットされていません");
        }

        if (echolocationCountTextObject == null) {
            Debug.Log("echolocationCountTextObjectがセットされていません: echolocationCountを出力したいテキストオブジェクトをinspectorからScene04Managerにアタッチしてください.");
        }
        if (resultTextObject == null) {
            Debug.Log("clearTimeTextObjectがセットされていません: clearTimeを出力したいテキストオブジェクトをinspectorからScene04Managerにアタッチしてください.");
        }
        //resultで移動を再現するための位置座標リスト.
        posList = Scene03Manager.GetPosList(); // 初期化処理
        buttonImage = buttonImageObject.GetComponent<Image>();
        echolocationCountText = echolocationCountTextObject.GetComponent<Text>();
        echolocationCountText.text = "Your Echolocation Count: " + Scene03Manager.GetEcholocationCount() + " times";
        int clearTime = Scene03Manager.GetClearTime();

        resultText = resultTextObject.GetComponent<Text>();
        if (clearTime >= 0) {
            int minute = clearTime / 60;
            int seconds = clearTime - minute * 60;
            resultText.text = "Your Clear Time: " + minute + "\' " + seconds + "\"";
        } else { //クリアに失敗した場合
            int progressStatus = Scene03Manager.GetProgressState;
            resultText.text = timeupMessage[progressStatus];
        }

        Invoke("ButtonManager", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (posList != null) {
            if (iCnt < posList.Count) {
                mirror.transform.position = posList[iCnt];
                iCnt　+= 2;
            }
        }

        if (canSkip && OVRInput.GetDown(OVRInput.RawButton.A)) {
            Invoke("ChangeScene", 0f);
        }
    }

        void ChangeScene()
    {
        SceneManager.LoadScene("Scene05");
    }

    void ButtonManager() {
        buttonImage.sprite = Resources.Load<Sprite>("Scene04_AButton");
        canSkip = true;
    }
}