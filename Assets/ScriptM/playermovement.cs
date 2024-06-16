using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;

    public float speed;

    public float jump;
    private Animator anim;

    bool grounded;

    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump * 10));
            anim.SetTrigger("jump");
        }

        if (Move != 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (!isFacingRight && Move > 0)
        {
            Flip();
        }
        else if (isFacingRight && Move < 0)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = true;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            grounded = false;

        }
    }   
}
