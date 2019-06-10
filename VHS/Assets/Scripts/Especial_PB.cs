using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Especial_PB : MonoBehaviour
{
    public Movement info;
    public GameMaster checkpoint;
    public Transform playerPos;
    public int gaugeControl = 20;
    public int lifeSurplus = 3;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        info = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        checkpoint = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)){
            if(info.specialGauge >= gaugeControl){
                info.specialGauge -= gaugeControl;
                info.healthDoMalandro(lifeSurplus);
                playerPos.position = checkpoint.lastCheckPointPos;
                FindObjectOfType<AudioManager>().Play("Rewind");
            }
        }
    }
}
