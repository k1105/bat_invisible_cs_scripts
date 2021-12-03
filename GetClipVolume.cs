using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetClipVolume : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource aud;
    void Start()
    {
        aud = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float vol = GetAveragedVolume(aud);
        if (vol != 0) {
            Debug.Log(vol);   
        }
    }

    float GetAveragedVolume(AudioSource audio) {
      float[] data = new float[256];
      float a = 0;
      audio.clip.GetData( data, 0 );
      foreach (float s in data) { a += Mathf.Abs(s); }
      return a/256.0f;
    }
}
