using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial_Pause : MonoBehaviour
{
    public PlayerState player;
    public bool especialPause = false;
    public float time = 5f;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (player.specialGauge >= 20)
            {
                especialPause = true;
                player.specialGauge = player.specialGauge - 20;
            }
                
            else
                return;
        }
    }

    private void WaitForSeconds(int v)
    {
        throw new NotImplementedException();
    }
}
