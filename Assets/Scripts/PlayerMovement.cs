using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float speed;
    public float speed = 5f;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
   
    private Rigidbody2D body;

    private Animator anim;

    //private bool grounded;

    private CapsuleCollider2D capsuleCollider;

    private float wallJumpCooldown;

    private float horizontalInput;
    public Coin coin;
    public static PlayerMovement instance;

    [Header("SFX")] 
    [SerializeField] private AudioClip jumpSound;
    
    
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
       
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        
        //change the player faces when use a/d
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
        
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());

        if (wallJumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
                if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                    SoundManager.instance.PlaySound(jumpSound);
            }
                
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    private void Jump()
    {
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("Jump");
        }
        else if (onWall() && !isGrounded())
        {
            if (horizontalInput == 0) 
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 0);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
           
            wallJumpCooldown = 0;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // if (collision.gameObject.tag == "Ground")
         //   grounded = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    private bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coin.coinCount++;
        }
    }
}