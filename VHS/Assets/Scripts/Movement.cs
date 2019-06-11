using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Movement : MonoBehaviour
{


    private Rigidbody rb;
    private Transform groundCheck;
    private Animator anim;
    private GameMaster gm; 

    private bool onGround;
    private bool isDead = false;
    private bool facingRight = true;
    private int currentHealth;
    private float currentSpeed;
    public float minHeight, maxHeight;
    public float maxWidth, minWidth;
    public int playerHealth = 10;
    public int specialGauge=0;
    public string playerName;

    public Especial_FF ff;
    public static bool DeathUI = false;
    public GameObject DeathMenuUI;

    public int pontuacaoTotal = 0;

    public Vector2 checkpointPosition;


    [SerializeField]
    private float velocidade = 0;

    float horizontal;
    float vertical;
    void Awake() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
		gm.lastCheckPointPos = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        groundCheck = gameObject.transform.Find("GroundCheck");
        currentSpeed = velocidade;
        currentHealth = playerHealth;
        FindObjectOfType<AudioManager>().Play("Cenario1");

    }


    public void healthDoMalandro(int lifeSurplus){
        currentHealth += lifeSurplus;
    }
    // Update is called once per frame

    void Update()
    {
        if (Pause_Menu.GameIsPaused)
            return;

        anim.SetBool("OnGround",onGround);
        anim.SetBool("Dead", isDead);
        onGround = Physics.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (currentHealth < 1)
        {
            Debug.Log("YOU'RE DEAD");
            isDead = true;
            SceneManager.LoadScene("MenuInicial");
            //transform.position = gm.lastCheckPointPos;
        }
        if(isDead == true){
            currentHealth = 10;
            isDead = false;
        }
        if (Input.GetKeyDown("a"))
        {
            anim.SetTrigger("Attack");

        }

        if (Input.GetKeyDown("s"))
        {
            anim.SetTrigger("Attack2");
        }

        if (isDead)
        {
            OpenMenu();
        }
        else
            CloseMenu();
    }
    private void FixedUpdate()
    {
        if (Pause_Menu.GameIsPaused)
            return;

        if (ff.especial_FF == true)
        {
            ff.especial_FF = false;
            StartCoroutine(GottaGoFast());
        }

        if (!isDead)
        {

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(horizontal * currentSpeed, rb.velocity.y, vertical * currentSpeed);
            anim.SetFloat("Speed",Mathf.Abs(horizontal));
            anim.SetFloat("Speed2",Mathf.Abs(vertical));
            
        }

        if (!onGround)
        {
            vertical = 0;
        }


        if (horizontal > 0 && !facingRight)
        {
            
            Flip();
            
        }
        else
        {
            if (horizontal < 0 && facingRight)
            {
                
                Flip();
                
            }
        }



        minWidth = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        maxWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,0,10)).x;
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minWidth + 1, maxWidth - 1), rb.position.y, Mathf.Clamp(rb.position.z, minHeight + 1, maxHeight - 1));

    }

    private void Flip()
    {
        
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        
    }

    void ZeroSpeed()
    {
        currentSpeed = 0;
    }

    void ResetSpeed()
    {
        currentSpeed = velocidade;
    }

    public void takeDmg(int damage)
    {
        if (!isDead)
        {
            
            currentHealth -= damage;
            anim.SetTrigger("HitDamage");
            FindObjectOfType<UIManager>().UpdateHealth(currentHealth);
        }

    }

    IEnumerator GottaGoFast()
    {
        currentSpeed = currentSpeed * 2;
        yield return new WaitForSeconds(ff.time);
        currentSpeed = currentSpeed / 2;
    }

    void OpenMenu()
    {
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        DeathUI = true;
    }

    void CloseMenu()
    {
        DeathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        DeathUI = false;
    }

}
