using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed Variables
    [SerializeField]
    private float moveSpeed = 3f;
    [SerializeField]
    private float jumpSpeed = 4f;

    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private DistanceJoint2D dj;
    private SpriteRenderer sr;

    public LayerMask jumpableGround;

    [SerializeField]
    private bool hookAvailable;

    public Sprite baseSprite;
    public Sprite secondSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cc = this.GetComponent<CapsuleCollider2D>();
        dj = this.GetComponent<DistanceJoint2D>();

        sr = this.GetComponent<SpriteRenderer>();

        //Sets the anchor point to us then turns the Joint off.
        dj.enabled = false;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        //Gets Input from unity horizontal axis. Raw determines that it is always only -1, 0, or 1.
        float dirX = Input.GetAxisRaw("Horizontal");

        //Multiplies the direction by our speed, then feeds that plus our current y velocity to our rigidbody so it only effects our x direction.
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        sr.sprite = baseSprite;

        //Checks if the player is grounded, if so resets our ability to have the option to hook.
        if (isGrounded())
        {
            hookAvailable = false;
        }

        //Checks to see if any of "Space, W, Up Arrow" are pressed and if we are grounded, if so we jump.
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }

        // Checks to see if the condition that we can hook as been met.
        // The current condition is as follows: Key is being pressed, we are within the radius of a hookpoint to hook, and we are not grounded.
        if (Input.GetKey(KeyCode.LeftShift) && hookAvailable && !isGrounded())
        {
            // Turns on the distance joint to perform the swing.
            dj.enabled = true;

        }
        // If any of the condition is not met, meaning we are not attempting to swing. We turn the DistanceJoint2D off.
        else
        {
            
            dj.enabled = false;
        }

        if (dj.enabled)
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HookPoint")
        {
            hookAvailable = true;
            dj.connectedBody = collision.attachedRigidbody;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(cc.bounds.center, cc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
