using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartScene : MonoBehaviour
{
    public void StartSceneBtn()
    {
        SceneManager.LoadScene("OJHScene");
        // if (!GameManager.instance.isLive)
        // {
        //     GameManager.instance.isLive = true;
        //     Time.timeScale = 1;
        // }
    }
}
