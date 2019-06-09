using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
	private GameMaster gm;
    private GameObject Enemy;

	void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void OnTriggerEnter(Collider other)
	{
        Debug.Log("entrei");
		if (other.CompareTag("Player"))
		{
            int enemysLeft = 0;
			if(enemysLeft == 0) gm.lastCheckPointPos = transform.position;  
		}
	}

}
