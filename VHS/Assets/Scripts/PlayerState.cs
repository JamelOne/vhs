using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerHealth = 5;
    private bool morto=false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!morto){
        
        if(playerHealth < 1) {
            Debug.Log("You're deaddddd");
            morto=true;
            SceneManager.LoadScene("MenuInicial");
        }
        }
    }

    public void takeDmg (int damage) {
        playerHealth-=damage;
        Debug.Log("Inimigo Atacou!");
    }
}
