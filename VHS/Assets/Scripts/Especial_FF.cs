using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial_FF : MonoBehaviour
{
    public Movement player;
    public bool especial_FF = false;
    public float time = 5f;
    public int gaugeNeeded = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(player.specialGauge >= gaugeNeeded)
            {
                especial_FF = true;
                player.specialGauge = player.specialGauge - gaugeNeeded;
            }
        }
    }
}
