using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private Rigidbody rb;
    private Transform groundCheck;
    private Animator anim;
    private bool onGround;
    private bool facingRight = true;
    private Transform target;
    private bool isDead = false;
    private float zForce;
    private float walkTimer;
    private float currentSpeed;
    private bool damaged = false;
    private float damageTimer;
    private int currentHealth;
    private float nextAttack;


    public float minHeight, maxHeight;
    public int maxHealth;
    public float attackRate = 1f;
    public float damageTime = 0.5f;
    public float maxSpeed = 2;
    public string enemyName;
    public Especial_Pause e_pause;
    public Movement player;
    public int gaugeGain = 2;   // Quanto o player ganha de Especial Gauge quando o inimigo morrer

    public int pontuacaoPorInimigo = 100;

    



    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        anim=GetComponent<Animator>();
        groundCheck=transform.Find("GroundCheck");
        target = FindObjectOfType<Movement>().transform;
        currentHealth=maxHealth;
    }

void Update()
    {
        
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1<<LayerMask.NameToLayer("Ground"));        
        anim.SetBool("Dead", isDead);
        facingRight = (target.position.x < transform.position.x) ? false : true;
        if(facingRight && !isDead)
        {
            if(!isDead)
            transform.eulerAngles = new Vector3(0,0,0);
        }else{
            if(!isDead)
            transform.eulerAngles = new Vector3(0,180,0);
        }

        
        if(damaged && !isDead){
            damageTimer += Time.deltaTime;
            if(damageTimer >= damageTime){
                damaged=false;
                damageTimer=0;
            }
        }
        walkTimer += Time.deltaTime;

   }

   private void FixedUpdate(){

        if (e_pause.especialPause == true)
        {
            StartCoroutine(PauseEnemyMovement());
        }

       
       
       if(!isDead){
            Vector3 targetDistance = target.position - transform.position;
            float hForce=targetDistance.x / Mathf.Abs(targetDistance.x);

            
        if(walkTimer >= Random.Range(1f,2f))
        {
            zForce = Random.Range(-1,2);
            walkTimer=0;
        }

        if(Mathf.Abs(targetDistance.x) < 1.5f) 
        {
            hForce=0;
        }
       

       if(!damaged){
           rb.velocity= new Vector3(hForce*currentSpeed,0,zForce*currentSpeed);
            anim.SetFloat("Speed", Mathf.Abs(currentSpeed));
       }

       
        if(Mathf.Abs(targetDistance.x)<1.5f && Mathf.Abs(targetDistance.z) <1.5f && Time.time > nextAttack&&!isDead)
        {
            anim.SetTrigger("Attack");
            currentSpeed=0;
            nextAttack=Time.time+attackRate;
            Debug.Log(nextAttack);
            Debug.Log("Time.time");
            Debug.Log(Time.time);
        }
            
       
   }
    
   rb.position = new Vector3 (rb.position.x,rb.position.y,Mathf.Clamp(rb.position.z,minHeight, maxHeight));
    
   }

public void TookDamage(int damage){
    if(!isDead)
    {
        
        damaged = true;
        currentHealth-=damage;
        anim.SetTrigger("HitDamage");
        FindObjectOfType<UIManager>().UpdateEnemyUI(maxHealth, currentHealth, enemyName);
        if(currentHealth <=0){
            player.specialGauge = player.specialGauge + gaugeGain;
            player.pontuacaoTotal = player.pontuacaoTotal + pontuacaoPorInimigo;
            isDead=true;
            rb.AddRelativeForce(new Vector3(-3,5,0),ForceMode.Impulse);
        }
    }
}

public void DisableEnemy(){
    gameObject.SetActive(false);
}


    void ResetSpeed()
    {
        currentSpeed=maxSpeed;
    }

    IEnumerator PauseEnemyMovement()
    {
        
        //Debug.Log(maxSpeed_backup); 

        attackRate = 0f;
        damageTime = 0f;
        maxSpeed = 0f;

        yield return new WaitForSeconds(e_pause.time);

        Debug.Log("Devolvendo valores de attack e velocidade");
        e_pause.especialPause = false;
        attackRate = 1f;
        damageTime = 0.5f;
        maxSpeed = 2;
        Debug.Log(maxSpeed);

    }
    void ZeroSpeed()
    {
        currentSpeed = 0;
    }

}

