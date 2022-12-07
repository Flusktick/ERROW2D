using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed = 10f;
    [SerializeField] private Rigidbody2D rb;


    private float horizontal;
    private Vector2 moveAmount;
    private Animator anim;
    private bool isFacingRight = true;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        rb.MovePosition(rb.position + moveAmount * Time.fixedDeltaTime);
        horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 moveInput = new Vector2(horizontal, 0);
        moveAmount = moveInput.normalized * Speed;

        if (moveInput != Vector2.zero)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        flip();

    }
  
    private void flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }


    }

}
