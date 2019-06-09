using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        PlayerState playerstate = other.GetComponent<PlayerState>();
        if(enemy!=null){
            enemy.TookDamage(damage);
        }
        if(playerstate!=null){
            playerstate.takeDmg(damage);
        }
    }
}
