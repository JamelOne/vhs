using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float maxZ,minZ;
    public GameObject[] enemy;
    public int numberOfEnemies;
    public float spawnTime;
    private int currentEnemies;

    private GameMaster gm;
    private GameObject Enemy;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnemies>=numberOfEnemies){
            int enemies=FindObjectsOfType<Enemy>().Length;
            if(enemies<=1){
                FindObjectOfType<CameraFollow>().maxXAndY.x=200;
                gameObject.SetActive(false);
                gm.lastCheckPointPos = playerPos.position; 
            }
        }
    }

    void SpawnEnemy(){
        bool positionX = Random.Range(0,2) == 0 ? true : false;
        Vector3 spawnPosition;
        spawnPosition.z = Random.Range(minZ,maxZ);
        if(positionX){
            spawnPosition = new Vector3(transform.position.x + 10,0,spawnPosition.z);
        }else{
            spawnPosition = new Vector3(transform.position.x - 10,0,spawnPosition.z);
        }
        Instantiate(enemy[Random.Range(0,enemy.Length)],spawnPosition,Quaternion.identity);
        currentEnemies++;
        if(currentEnemies < numberOfEnemies){
            Invoke("SpawnEnemy",spawnTime);
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            GetComponent<BoxCollider>().enabled=false;
            FindObjectOfType<CameraFollow>().maxXAndY.x = transform.position.x;
            SpawnEnemy();
            
		    
        }
    }
}
