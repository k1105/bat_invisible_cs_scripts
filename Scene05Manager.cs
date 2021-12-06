using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene05Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 15f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Scene01");
    }
}
