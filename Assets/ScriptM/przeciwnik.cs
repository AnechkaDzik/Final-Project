using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class przeciwnik : MonoBehaviour
{
    private Rigidbody2D rb;

    private float Move;

    public float speed;
    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
    }
    public int start;
    public int end;
    // Update is called once per frame
    void Update()
    {
        if (rb.position.x < start)
        {
            isFacingRight = true;
            rb.position = new Vector2(start, rb.position.y);
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
        if (rb.position.x > end)
        {
            isFacingRight = false;
            rb.position = new Vector2(end, rb.position.y);
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        if (isFacingRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }

        
    }
}
