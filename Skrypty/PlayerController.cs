using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform ladderCheck;
    public float ladderCheckRadius;
    public LayerMask whatIsLadder;
    private bool ladder;

    private bool doubleJumped;

    private Animator anim;

    public Transform firePoint;
    public GameObject woddenArrow;

    public AudioClip moveSound1;
    public AudioClip moveSound2;

    //public float shotDelay;
    //private float shotDelayCounter;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    private Rigidbody2D myrigidbody2D;

    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity;
    private float gravityStore;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

        myrigidbody2D = GetComponent<Rigidbody2D>();

        gravityStore = myrigidbody2D.gravityScale;
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        ladder = Physics2D.OverlapCircle(ladderCheck.position, ladderCheckRadius, whatIsLadder);
    }

    // Update is called once per frame
    void Update () {

        if (grounded)
            doubleJumped = false;

        anim.SetBool("Grounded", grounded);

        //if (ladder)

            //anim.SetBool("Climbing", ladder);

        if(Input.GetButton("Jump") && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
           
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        {
               GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            doubleJumped = true;
        }

        //moveVelocity = 0f;

       moveVelocity =  moveSpeed * Input.GetAxisRaw("Horizontal");

        if (knockbackCount <= 0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        } 
        else
        {
            if (knockFromRight)
                myrigidbody2D.velocity = new Vector2(-knockback, knockback);
            if(!knockFromRight)
                myrigidbody2D.velocity = new Vector2(knockback, knockback);
            knockbackCount -= Time.deltaTime;

           

        }
        

            anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

            if (GetComponent<Rigidbody2D>().velocity.x > 0)
                transform.localScale = new Vector3(1f, 1f, 1f);
            else if (GetComponent<Rigidbody2D>().velocity.x < 0)
                transform.localScale = new Vector3(-1f, 1f, 1f);


            if (Input.GetButtonDown("ArcAttack"))
            {
                GetComponent<Animator>().SetTrigger("Shoot");
             Instantiate(woddenArrow, firePoint.position, firePoint.rotation);

        }
        
        //shotDelayCounter = shotDelay;


        //if(Input.GetKey(KeyCode.X))
        {
            //shotDelayCounter -= Time.deltaTime;

            //if(shotDelayCounter <= 0)
            {
                //shotDelayCounter = shotDelay;
                //Instantiate(woddenArrow, firePoint.position, firePoint.rotation);
            }

            

        }
        if (anim.GetBool("Sword"))
            anim.SetBool("Sword", false);

        if(Input.GetButtonDown("SwordAttack"))
        {
            anim.SetBool("Sword", true);
        }

        if (Input.GetButtonDown("Roll"))
        {
            GetComponent<Animator>().SetTrigger("Roll");
        }

        if (onLadder)
        {
           

            GetComponent<Rigidbody2D>().gravityScale = 0f;

            climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");

            anim.SetBool("Climbing", true);

            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, climbVelocity);  
        }

        if(!onLadder)
        {
            GetComponent<Rigidbody2D>().gravityScale = gravityStore;
            anim.SetBool("Climbing", false);

        }
       
    }

}
