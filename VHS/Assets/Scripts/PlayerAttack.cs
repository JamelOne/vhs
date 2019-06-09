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
        Movement player = other.GetComponent<Movement>();
        if(enemy!=null){
            enemy.TookDamage(damage);
        }
        if(player!=null){
            player.takeDmg(damage);
       }
    }
}
