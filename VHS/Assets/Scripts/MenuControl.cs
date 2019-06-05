using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public string nextScene;
    
    public void changeScene () {
        Debug.Log(nextScene);
        //SceneManager.LoadScene(nextScene);
    }

    public void quitApplication () {
        Application.Quit();
    }

}
