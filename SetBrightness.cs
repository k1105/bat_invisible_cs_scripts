using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public static class SetBrightness
{
    /// <summary>
    /// Objectの明るさをコントロールする
    /// </summary>
    public static IEnumerator FadeIn(this Material obj)
    {
        Color c = obj.color;
        c.r = 0;
        c.g = 0;
        c.b = 0;
        float time = 0.0f;
        while(time <= 1.0f) {
            time += Time.deltaTime;
            yield return null;
        }
        while(c.r <= 1.0f) {
            c.r += Time.deltaTime/3;
            c.g += Time.deltaTime/3;
            c.b += Time.deltaTime/3;
            obj.color = c;
            yield return null;
        }
    }
    
    public static IEnumerator FadeOut(this Material obj)
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