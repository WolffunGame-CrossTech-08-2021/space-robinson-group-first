using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : BaseMonoBehaviour
{
    public float moveSpeed = 5f;
    public Camera cam;

    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;

    private bool _facingRight = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public override void DoUpdate()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Move();
    }

    private void FixedUpdate()
    {
        

        // Vector2 lookDir = mousePos - rb.position;
        // float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        // rb.rotation = angle;
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (mousePos.x > transform.position.x && !_facingRight)
        {
            Flip();
        } else if (mousePos.x < transform.position.x && _facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        _facingRight = !_facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
