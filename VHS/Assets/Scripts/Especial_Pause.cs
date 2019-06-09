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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (player.specialGauge >= gaugeNeeded)
            {
                especialPause = true;
                player.specialGauge = player.specialGauge - gaugeNeeded;
            }
                
            else
                return;
        }
    }
}
