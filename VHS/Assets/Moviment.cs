using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Moviment : MonoBehaviour
{
    private Rigidbody2D rb2D;
    
    [SerializeField]
     private float velocidade = 0;
    float horizontal;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        
        Move(horizontal);
    }

    private void Move(float hor)
    {
        rb2D.velocity = new Vector2(hor*velocidade,rb2D.velocity.y);
    }

}
