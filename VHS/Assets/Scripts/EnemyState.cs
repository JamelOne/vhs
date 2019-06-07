using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public int enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth < 1) {
            Debug.Log("He's deaddddd");
        }
    }

    public void takeDmgEn () {
        enemyHealth--;
        //play sound
    }
}
