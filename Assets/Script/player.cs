using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 10f;
    public Vector2 moveVector;
    private bool isFacingRaight = true;
    private Animator anim;
    public int jumpForce = 10;
    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    public float GroundCheckRadius = 0.03f;
    private Vector3 respawn;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        respawn = transform.position;
    }

    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
        anim.SetFloat("move", Mathf.Abs(moveVector.x));
        if (moveVector.x < 0 && isFacingRaight)
        {
            Filp();
        }
        if (moveVector.x > 0 && !isFacingRaight)

        {
            Filp();
        }
        Jump();
        ChekingGround();
    }
    void Filp()
    {
        isFacingRaight = !isFacingRaight;
        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
        transform.Rotate(0, 180, 0);
    }
    void Jump()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            /*anim.SetBool("jump", onGround);*/
        }
    }
    void ChekingGround()

    {
     onGround = Physics2D.OverlapCircle(GroundCheck.position,GroundCheckRadius,Ground);
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="deadzone")
        {
            transform.position = respawn;
        }else if (collision.tag =="checkpoint")
        {
            respawn = transform.position;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platforma"))
        {
            this.transform.parent = null;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platforma"))
        {
            this.transform.parent = collision.transform;
        }
    }

} 



  
        
 




