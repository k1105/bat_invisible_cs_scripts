using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using static SetBrightness;
using static VideoClipTransition;
public class Scene02Manager : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// image = UI上でボタン操作などで表示を切り替える対象となる画像.
    /// </summary>
    public GameObject stage;
    public GameObject player = null;
    public GameObject opponent = null;
    public GameObject videoPlane = null;

    private int windowState;
    private Vector3 prevPos;
    private Vector3 currentPos;
    private VideoPlayer videoPlayer;
    private RawImage videoContainer;
    private VideoClip src;
    private bool firstLoad = true;
    void Start()
    {
        windowState = 0;
        videoPlayer = videoPlane.GetComponent<VideoPlayer>();
        videoContainer = videoPlane.GetComponent<RawImage>();

        if(player == null) {
            Debug.Log("playerがセットされていません");
        }

        if (opponent == null) {
            Debug.Log("opponentがセットされていません");
        }
        prevPos = player.transform.position;
    }

    // Update is called once per frame
    void Update () {
        if(firstLoad) {
            StartCoroutine(stage.GetComponent<Renderer>().material.FadeIn());
            src = Resources.Load<VideoClip>("UI1");
            StartCoroutine(videoContainer.Transit(src));
            firstLoad = false;
        }

        if (OVRInput.GetDown(OVRInput.RawButton.A) && !videoContainer.IsTransition()) { // なおす
            if ( windowState == 0 ) {
                src = Resources.Load<VideoClip>("UI2");
                StartCoroutine(videoContainer.Transit(src));
                windowState = 1;
            }

            else if ( windowState == 1 ) {
                src = Resources.Load<VideoClip>("UI3");
                StartCoroutine(videoContainer.Transit(src));
                windowState = 2;
            }

            else if ( windowState == 2 ) {
                src = Resources.Load<VideoClip>("UI4");
                StartCoroutine(videoContainer.Transit(src));
                windowState = 3;
            }
            
            else if ( windowState == 3 ) {
                src = Resources.Load<VideoClip>("UI5");
                StartCoroutine(videoContainer.Transit(src));
                windowState = 4;
            }

            else if ( windowState == 4 ) {
                src = Resources.Load<VideoClip>("UI6");
                StartCoroutine(videoContainer.Transit(src));
                windowState = 5;
            }
        }

        currentPos = player.transform.position;
        Vector3 delta = currentPos - prevPos;

        RaycastHit wallHit;

        if ( Physics.SphereCast(currentPos, 0.1f, delta, out wallHit, 0.5f) || (Physics.SphereCast(currentPos, 0.1f, -delta, out wallHit, 0.5f)) && windowState == 4 ) {
            if (wallHit.collider.name == opponent.name) {
                StartCoroutine(stage.GetComponent<Renderer>().material.FadeOut());
                Invoke("ChangeScene", 5f);
            }
        }

        prevPos = currentPos;
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene03");
    }
}