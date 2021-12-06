using UnityEngine;
using System.Linq;

[RequireComponent(typeof(MultiEcholocationController))]
public class EcholocationTriggerVoice : MonoBehaviour
{
    public float threshold = 0.03f; // Echolocationを発動させる音量のしきい値
    private MultiEcholocationController controller;
    private Camera mainCamera;
    private AudioSource aud;
    protected static bool emitStatus;

    private void Start()
    {
        this.mainCamera = Camera.main;
        this.controller = this.GetComponent<MultiEcholocationController>();
        aud = GetComponent<AudioSource>();
        aud.clip = Microphone.Start(null, true, 999, 44100);
        // マイクからのAudio-InをAudioSourceに流す
        aud.loop = true;
        // ループ再生にしておく
        while (!(Microphone.GetPosition("") > 0)){}
        // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
        aud.Play();
        // 再生する
    }

    private void Update()
    {
        float vol = GetAveragedVolume(aud);

        // if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.mainCamera.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        if ( vol > threshold )
        {
            emitStatus = true;
            this.controller.EmitCall(this.mainCamera.transform.position);
        } else {
            emitStatus = false;
        }
    }

    float GetAveragedVolume(AudioSource audio) {
      float[] data = new float[256];
      float a = 0;
      audio.GetOutputData( data, 0 );
      foreach (float s in data) { a += Mathf.Abs(s); }
      return a/256.0f;
    }

    public static bool GetEmitStatus() {
        return emitStatus;
    }
}