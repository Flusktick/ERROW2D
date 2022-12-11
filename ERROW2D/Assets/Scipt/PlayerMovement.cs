using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float Speed;
    private float moveInput;
    public Rigidbody2D rb;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    [SerializeField]public float jumpTime;
    private bool isJumping;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();



    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
       
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
     
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

    }
    void Update()
    {

       isGrounded = Physics2D.OverlapCircle(feetPos.position ,checkRadius,whatIsGround);

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }else if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.Space)&& isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
           
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

}
