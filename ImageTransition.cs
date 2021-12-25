// ImageTransition.cs
// author: k1105
using UnityEngine;
using UnityEngine.UI;
using static ImageOpacity;
using System.Collections;
public static class ImageTransition
{
    /// <summary>
    /// Imageのフェードイン, フェードアウトを行って画像を遷移させる.
    /// </summary>

    private static bool isTransition = false;
    public static IEnumerator Transit(this Image image, Sprite src)
    {
        isTransition = true;
        float opacity = 1.0f;
        // fadeOutの開始
        while(opacity > 0f) {
            opacity -= Time.deltaTime;
            image.SetOpacity(opacity);
            yield return null;
        }
        // fadeOutの終了
        
        // 画像の切り替え
        image.sprite = src;

        // fadeInの開始
        while(opacity < 1.0f) {
            opacity += Time.deltaTime;
            image.SetOpacity(opacity);
            yield return null;
        }
        // fadeInの終了

        isTransition = false;
    }

    public static bool IsTransition(this Image image) {
        return isTransition;
    }
}