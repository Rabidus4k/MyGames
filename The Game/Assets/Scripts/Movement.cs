using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speedX = 0f;
    public float speedY = 0f;
    private bool isJumping;
    public Animator animator;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {      
            MoveRight();
        } else if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        } else
        {
            Idle();        
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedX = 1F;
            animator.speed = 3F;
        } else
        {
            speedX = 0.5F;
            animator.speed = 1F;
        }
    }

    private void MoveRight()
    {
        animator.SetBool("isRunning", true);
        transform.localScale = new Vector3(10, 10, 0);
        transform.Translate(Vector3.right * speedX);
    }

    private void MoveLeft()
    {
        animator.SetBool("isRunning", true);
        transform.localScale = new Vector3(-10, 10, 0);
        transform.Translate(Vector3.left * speedX);
    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0, speedY), ForceMode2D.Impulse);
    }

    private void Idle()
    {
        animator.SetBool("isRunning", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isJumping = true;
    }

}
