using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class BrightnessDecrease
{
    /// <summary>
    /// Objectの明るさを徐々に下げて真っ暗にする
    /// </summary>
    public static IEnumerator SetBrightness(this Material obj)
    {
        Color c = obj.color;
        float max_brightness = Mathf.Max(c.r, Mathf.Max(c.b, c.g));
        float delta = max_brightness / 300; // 一番初めにRGBのうち最大のものを取得し, それを100で割る.
        while(max_brightness >= 0) {
            c.r -= Time.deltaTime/3;
            c.g -= Time.deltaTime/3;
            c.b -= Time.deltaTime/3;
            obj.color = c;
            yield return null;
        }
    }
}