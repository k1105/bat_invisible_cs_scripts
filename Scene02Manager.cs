using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scene02Manager : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// image = UI上でボタン操作などで表示を切り替える対象となる画像.
    /// </summary>
    public Image image;
    public GameObject player = null;
    public GameObject opponent = null;
    private int windowState;
    private Sprite sprite;
    private Vector3 prevPos;
    private Vector3 currentPos;
    private Image targetImage;
    void Start()
    {
        windowState = 0;
        targetImage = image.GetComponent<Image>();
        if (targetImage == null) {
            Debug.Log("targetImageがセットされていません");
        }

        if(player == null) {
            Debug.Log("playerがセットされていません");
        }

        if (opponent == null) {
            Debug.Log("opponentがセットされていません");
        }
        targetImage = image.GetComponent<Image>();
        prevPos = player.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.A)) {
            if ( windowState == 0 ) {
                targetImage.sprite = Resources.Load<Sprite>("Scene02_02Stick");
                windowState = 1;
            }

            else if ( windowState == 1 ) {
                sprite = Resources.Load<Sprite>("Scene02_03Face");
                targetImage.sprite = sprite;
                windowState = 2;
            }

            else if ( windowState == 2 ) {
                sprite = Resources.Load<Sprite>("Scene02_03Walk");
                targetImage.sprite = sprite;
                windowState = 3;
            }
        }

        currentPos = player.transform.position;
        Vector3 delta = currentPos - prevPos;

        RaycastHit wallHit;

        if ( Physics.SphereCast(currentPos, 0.1f, delta, out wallHit, 0.5f) || (Physics.SphereCast(currentPos, 0.1f, -delta, out wallHit, 0.5f)) && windowState == 3 ) {
            if (wallHit.collider.name == opponent.name) {
                Invoke("ChangeScene", 0f);
            }
        }

        prevPos = currentPos;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene03");
    }
}
