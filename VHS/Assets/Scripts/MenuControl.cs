using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    public string nextScene;
    
    public void changeScene () {
        SceneManager.LoadScene("Jogo");
    }

    public void quitApplication () {
        Application.Quit();
    }

}
