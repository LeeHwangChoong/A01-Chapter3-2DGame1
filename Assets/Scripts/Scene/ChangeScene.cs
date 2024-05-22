using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name)
        {
            case "Restart Button":
                SceneManager.LoadScene("OJHScene");
                break;
            case "Home Button":
                SceneManager.LoadScene("GameStartScene");
                break;

        }
    }    

}
