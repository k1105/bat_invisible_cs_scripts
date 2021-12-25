// VlideoClipTransition.cs
// author: k1105
using UnityEngine;
using UnityEngine.UI;
// using static ImageOpacity;
using System.Collections;
using UnityEngine.Video;
public static class VideoClipTransition
{
    /// <summary>
    /// VideoClipのフェードイン, フェードアウトを行って画像を遷移させる.
    /// </summary>

    private static bool isTransition = false;
    private static VideoPlayer player;
    public static IEnumerator Transit(this RawImage image, VideoClip src)
    {
        player = image.GetComponent<VideoPlayer>();
        isTransition = true;
        float opacity ;
        if(player.clip == null) {
            Debug.Log("null");
            opacity = 0.0f;
        } else {
            opacity = 1.0f;
        }
        // fadeOutの開始
        while(opacity > 0f) {
            opacity -= Time.deltaTime;
            image.color = new Color(1, 1, 1, opacity);
            yield return null;
        }
        // fadeOutの終了
        player.Stop();
        // 画像の切り替え
        player.clip = src;
        player.Play();

        float time = 0f;
        while(time < 0.5f) { //0.5s待機
            time += Time.deltaTime;
            yield return null;
        }

        // fadeInの開始
        while(opacity < 1.0f) {
            opacity += Time.deltaTime;
            image.color = new Color(1, 1, 1, opacity);
            yield return null;
        }
        // fadeInの終了

        isTransition = false;
    }

    public static bool IsTransition(this RawImage image) {
        return isTransition;
    }
}