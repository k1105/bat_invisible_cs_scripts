using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static ImageTransition;

public class Scene03Manager : MonoBehaviour
{
    //　トータル制限時間
    private float totalTime;
    //  残り時間
    private float leftTime;
    //　制限時間（分）
    [SerializeField] public int minute;
    //　制限時間（秒）
    [SerializeField] public float seconds;
    //　前回Update時の秒数
    private float oldSeconds;
    protected static float clearTime;
    protected static int progressState;
    public GameObject player = null;
    public GameObject infoImageObject;
    public GameObject progressImageObject;
    private int windowState = 0;
    protected static List<Vector3> posList;
    protected static List<Quaternion> rotList;
    private Vector3 prevPos;
    private bool isCleared = false;
    private bool isTimeUp = false;
    private Vector3 currentPos;
    private Image infoImage;
    private Image progressImage;
    private bool currentEmitStatus;
    private bool prevEmitStatus;
    protected static int echolocationCount;
    // Start is called before the first frame update
    void Start () {
        if(player == null) {
            Debug.Log("playerがセットされていません");
        }
        totalTime = minute * 60 + seconds;
        leftTime = totalTime;
        oldSeconds = 0f;
        //カンバスのゲームオブジェクトを取得
        infoImage = infoImageObject.GetComponent<Image>();
        progressImage = progressImageObject.GetComponent<Image>();
        //衝突判定用に必要な, 前フレームでのplayerの位置を格納.
        prevPos = player.transform.position;

        //resultで移動を再現するための位置座標リスト.
        posList = new List<Vector3>(); // 初期化処理
        rotList = new List<Quaternion>();
        posList.Add(player.transform.position); //最初の座標の代入
        rotList.Add(player.transform.rotation);

        echolocationCount = 0; //初期化処理
        clearTime = -1.0f; //timeUp時にclearTimeを表示させないために, 有効範囲外の数字を初期値として代入しておく.
        progressState = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) && !infoImage.IsTransition()) {
            if ( windowState == 0 ) {
                StartCoroutine(infoImage.Transit(Resources.Load<Sprite>("Scene03_02Bat")));
                windowState = 1;
            }

            else if ( windowState == 1 ) {
                StartCoroutine(infoImage.Transit(Resources.Load<Sprite>("Scene03_03Speak_01")));
                windowState = 2;
            }

            else if ( windowState == 2 ) {
                StartCoroutine(infoImage.Transit(Resources.Load<Sprite>("Scene03_03Speak_02")));
                windowState = 3;
            }

            else if ( windowState == 3 ) {
                StartCoroutine(infoImage.Transit(Resources.Load<Sprite>("Scene03_04Let's")));
                windowState = 4;
            }
            
            else if ( windowState == 4 ) {
                StartCoroutine(infoImage.Transit(Resources.Load<Sprite>("Scene04_Transparent")));
                windowState = 5;
            }
        }

        if(!isCleared) { //残り時間の計算
            leftTime = minute * 60 + seconds;
            leftTime -= Time.deltaTime;

            //　再設定
            minute = (int) leftTime / 60;
            seconds = leftTime - minute * 60;
            oldSeconds = seconds;
        }

        //衝突判定
        currentPos = player.transform.position;
        Vector3 delta = currentPos - prevPos;

        RaycastHit wallHit;

        if ( Physics.SphereCast(currentPos, 0.1f, delta, out wallHit, 0.5f) || (Physics.SphereCast(currentPos, 0.1f, -delta, out wallHit, 0.5f))) {
            if (wallHit.collider.name == "Checkpoint01") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_01");
                progressState = 1;
            } else if (wallHit.collider.name == "Checkpoint02") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_02");
                progressState = 2;
            } else if (wallHit.collider.name == "Checkpoint03") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_03");
                progressState = 3;
            } else if (wallHit.collider.name == "Checkpoint04") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_04");
                progressState = 4;
            } else if (wallHit.collider.name == "Checkpoint05") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_05");
                progressState = 5;
            } else if (wallHit.collider.name == "Checkpoint06") {
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_06");
                progressState = 6;
            } else if (wallHit.collider.name == "Goalpoint" && !isTimeUp) { //clear!
                progressImage.sprite = Resources.Load<Sprite>("Scene03_Progress_Goal");
                infoImage.sprite = Resources.Load<Sprite>("Scene03_05Clear");
                isCleared = true;
                clearTime = totalTime - leftTime;
                Invoke("ChangeScene", 10f);
            }
        }
        
        if(leftTime <= 0f && !isCleared) {//　timeup!
                infoImage.sprite = Resources.Load<Sprite>("Scene03_10TimeUp");
                isTimeUp = true;
                Invoke("ChangeScene", 10f);
        }
        // リストに今の位置座標を格納.
        posList.Add(player.transform.position);
        rotList.Add(player.transform.rotation);

        // 衝突判定ようにprevPosの更新.
        prevPos = currentPos;

        // echolocationCountの更新処理
        currentEmitStatus = EcholocationTriggerVoice.GetEmitStatus();
         if(currentEmitStatus && !prevEmitStatus) {
             echolocationCount++;
         }

         prevEmitStatus = currentEmitStatus;

    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene04");
    }

    public static List<Vector3> GetPosList() {
        return posList;
    }

    public static List<Quaternion> GetRotList() {
        return rotList;
    }

    public static int GetEcholocationCount() {
        return echolocationCount;
    }

    public static int GetClearTime() {
        return (int) clearTime;
    }

    public static int GetProgressState() {
        return progressState;
    }
}