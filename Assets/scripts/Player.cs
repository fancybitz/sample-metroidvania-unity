using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private Vector2 speedForce = new Vector2(3, 0);
    private Vector2 jumpForce = new Vector2(0, 1.5f);
    private bool isLadder = false;
    private bool facingLeft = false;

    private float horiz = 0;
    private float vert = 0;


    private float raySpan = 0.1f;
    private Color raycastColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D.gravityScale = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.horiz = Input.GetAxis("Horizontal");
        this.vert = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horiz * speedForce.x, vert * speedForce.y);

        movement *= Time.deltaTime;

        rigidbody2D.transform.Translate(movement);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            // Calculate the distance from the surface and the "error" relative
            // to the floating height.
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log(hit.point.y);
        }

        if (!isLadder && isGrounded() && Input.GetKey(KeyCode.Space)) {
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Update()
    {
        if (horiz != 0) {
            if (horiz > 0)
            {
                facingLeft = false;
            }
            else {
                facingLeft = true;
            }
        }

        if (facingLeft)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private bool isGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + raySpan);
        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + raySpan), raycastColor);

        if (hit.collider != null)
        {
            raycastColor = Color.green;
        }
        else {
            raycastColor = Color.red;
        }

        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = true;

            rigidbody2D.gravityScale = 0;

            speedForce = new Vector2(3, 3);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            isLadder = false;

            rigidbody2D.gravityScale = 1;

            speedForce = new Vector2(3, 0);
        }
    }
}
