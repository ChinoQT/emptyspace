using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private float jumpFrc = 18f;
    [SerializeField] private AudioSource jumpSFX;
    [SerializeField] private AudioSource doubleJumpSFX;
    [SerializeField] private TrailRenderer tr;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coll;
    public Transform checkFront;
    bool faceingRight = true;
    public ParticleSystem dustTrail;

    private bool canDash = true;
    private bool isDashing;
    private float dashSpeed = 15f;
    private float dashTime = 0.2f;
    private float dashingCooldown = 1f;


    bool isGrounded;
    public static bool canDoubleJump;

    private float dirX = 0f;
    private enum MovementState { idle,running,jumping,falling } //Movement State of Character



    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDashing)
        {
            return;
        }

        isGrounded = Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);


        dirX = SimpleInput.GetAxis("Horizontal"); //Movement X
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpFrc);
            jumpSFX.Play();
            canDoubleJump = true;
        }


            
        UpdateAnimationState(); //Animation void call per frame

        if (dirX < 0 && faceingRight)
        {
            FlipCharacter();
        }
        else if (dirX > 0 && !faceingRight)
        {
            FlipCharacter();
        }

        //MOBILE JUMP
        if (CrossPlatformInputManager.GetButtonDown("JumpBTN") && rb == isGrounded)
        {
            jumpSFX.Play();
            anim.SetBool("doublejmp", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpFrc);
            canDoubleJump = true;
            createDust();

        }
        else if (CrossPlatformInputManager.GetButtonDown("JumpBTN") && canDoubleJump) //DOUBLE JUMP
        {
            anim.SetBool("doublejmp", true); //DoubleJump Animation
            screenShake.Instance.shakeCamera(2.5f, .2f);
            jumpFrc = jumpFrc - 2; //Lesser Jumpforce in double Jump
            rb.velocity = new Vector2(rb.velocity.x, jumpFrc);
            doubleJumpSFX.Play();
            canDoubleJump = false;
            jumpFrc = jumpFrc + 2;
            createDust();
        }

        //DASH
        if (CrossPlatformInputManager.GetButtonDown("DashBTN") && canDash)
        {
            StartCoroutine(Dash());
        }


    }
    private void FlipCharacter() //FLIP CHARACTER
    {
        faceingRight = !faceingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        //Movement Animation -- flip (left/right)
        if (dirX > 0f)
        {
            state = MovementState.running;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }


        anim.SetInteger("state", (int)state);
    }







    void createDust()
    {
        dustTrail.Play();
    }

    private IEnumerator Dash()
    {
        canDash = false; //Disabled the ability to dash
        isDashing = true; 
        float originalGravity = rb.gravityScale; 
        rb.gravityScale = 0f; //Set gravity to 0 while dashing
        rb.velocity = new Vector2(dirX * dashSpeed, 0f); //Add velocity to Dash
        tr.emitting = true; //Emit the TRAIL effect
        yield return new WaitForSeconds(dashTime); //WAIT in seconds according to value
        tr.emitting = false;
        rb.gravityScale = originalGravity; //Bring back OG Gravity
        isDashing = false; 
        yield return new WaitForSeconds(dashingCooldown); //Wait until cooldown is done
        canDash = true; //Then canDash to true
    }

}
