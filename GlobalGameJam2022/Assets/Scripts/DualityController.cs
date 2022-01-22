using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualityController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    float moveInput;

    Rigidbody2D rb;

    bool facingRight = true;
    bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask platforms;

    public int coyoteMax;
    int coyoteTime = 0;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.freezeRotation = true;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, platforms);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        else if (isGrounded)
        {
            coyoteTime = 0;
        }

        Debug.Log(coyoteTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            coyoteTime = 500;
        }
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTime <= coyoteMax)
        {
            Jump();
            coyoteTime = coyoteMax;
        }
        coyoteTime++;
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }
}

