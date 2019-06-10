using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial_Pause : MonoBehaviour
{
    public Movement player;
    public bool especialPause = false;
    public float time = 5f;
    public int gaugeNeeded = 20;

    public Animator anim;

     void Start()
    {
        anim=GetComponent<Animator>();
    }
    void Update()
    {
        Pause();
    }

    void Pause(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (player.specialGauge >= gaugeNeeded)
            {
                especialPause = true;
                anim.SetBool("Pause",especialPause);
                player.specialGauge = player.specialGauge - gaugeNeeded;
            }
                
            else
                return;
        }
    }
}
