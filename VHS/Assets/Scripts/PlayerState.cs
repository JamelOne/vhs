using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int playerHealth = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab)){
            takeDmg();
        }
        if(playerHealth < 1) {
            Debug.Log("You're deaddddd");
        }
    }

    public void takeDmg () {
        playerHealth--;
    }
}
