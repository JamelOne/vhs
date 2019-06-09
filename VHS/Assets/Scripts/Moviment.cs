using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moviment : MonoBehaviour
{
    
    
    private Rigidbody rb;
    private Transform groundCheck;
    private GameMaster gm; 
    private bool onGround;
    private bool isDead = false;
    private bool facingRight = true;
    
    private float currentSpeed;
    public float minHeight,maxHeight;

    [SerializeField]
     private float velocidade = 0;
    
    float horizontal;
    float vertical;

    void Awake() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		transform.position = gm.lastCheckPointPos;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = gameObject.transform.Find("GroundCheck");
        currentSpeed = velocidade;
    }

    // Update is called once per frame
    
    void Update()
    {
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1<<LayerMask.NameToLayer("Ground"));
    }
    private void FixedUpdate(){

        if(!isDead){
            
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(horizontal*currentSpeed,rb.velocity.y,vertical*currentSpeed);
        
        }

        if(!onGround)
            vertical=0;

        if(horizontal>0 && !facingRight){
            Flip();
        }else{
            if(horizontal<0 && facingRight){
                Flip();
            }
        }


       
       
        
        float minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0,0,10)).x;
        float maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,10)).x;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x,minWidth + 1,maxWidth - 1),
            rb.position.y,
            Mathf.Clamp(rb.position.z,minHeight + 1,maxHeight - 1));

        if(Input.GetButtonDown("Fire1")){
            Debug.Log("Atacando");
        }
    }

    private void Flip(){
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x*= -1;
        transform.localScale = scale;
    }

    void ZeroSpeed(){
        currentSpeed=0;
    }

    void ResetSpeed(){
        currentSpeed=velocidade;
    }
}
