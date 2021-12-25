using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene01Manager : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
      if (OVRInput.GetDown(OVRInput.RawButton.A)) {
        Invoke("ChangeScene", 0f);        
      }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene02");
    }
}