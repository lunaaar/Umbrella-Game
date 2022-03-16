using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Speed Variables

    /// <summary>
    /// Base movement speed for the player. Only effects horizontal movement.
    /// </summary>
    [SerializeField]
    private float moveSpeed = 3f;
    /// <summary>
    /// Base jump speed for the player. Only effects jump movement.
    /// </summary>
    [SerializeField]
    private float jumpSpeed = 4f;

    // References to Other Components

    private Rigidbody2D rigidBody;
    private CapsuleCollider2D capsuleCollider;
    private DistanceJoint2D distanceJoint;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// This is the Layer within unity that all the ground will be apart of, and what we consider to be counted as ground.
    /// </summary>
    public LayerMask jumpableGround;

    /// <summary>
    /// Boolean value that is true when we the conditions are met that allow us to perform a hook.
    ///      Current Condition: are we within a set radius of a Hook Point
    /// </summary>
    [SerializeField]
    private bool withinHookRadius;


    //Sprite Variables, used for testing purposes. Will have to encorperate something later but will almost certainly be removed or changed.
    // TODO: Look into this.
    public Sprite baseSprite;
    public Sprite secondSprite;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        capsuleCollider = this.GetComponent<CapsuleCollider2D>();
        distanceJoint = this.GetComponent<DistanceJoint2D>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();

        //Sets the anchor point to us then turns the Joint off.
        distanceJoint.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        // TODO: add condition that input is only taken when we are not actively hooking.
        
        //Gets Input from unity horizontal axis. Raw determines that it is always only -1, 0, or 1.
        float dirX = Input.GetAxisRaw("Horizontal");

        //Multiplies the direction by our speed, then feeds that plus our current y velocity to our rigidbody so it only effects our x direction.
        rigidBody.velocity = new Vector2(dirX * moveSpeed, rigidBody.velocity.y);

        spriteRenderer.sprite = baseSprite;

        //Checks if the player is grounded, if so resets our ability to have the option to hook.
        if (isGrounded())
        {
            withinHookRadius = false;
        }

        //Checks to see if any of "Space, W, Up Arrow" are pressed and if we are grounded, if so we jump.
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

        }

        // Checks to see if the condition that we can hook as been met.
        // The current condition is as follows: Key is being pressed, we are within the radius of a hookpoint to hook, and we are not grounded.
        if (Input.GetKey(KeyCode.LeftShift) && withinHookRadius && !isGrounded())
        {
            // Turns on the distance joint to perform the swing.
            distanceJoint.enabled = true;
            
            //Debug.Log("TEST");

            // TODO: Note that the above Debug is called every frame this condition is met to be true, add here some form of duration control that limits how long
            // a user can be hooked for.
        }
        // If any of the condition is not met, meaning we are not attempting to swing. We turn the DistanceJoint2D off.
        else
        {
            
            distanceJoint.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HookPoint")
        {
            withinHookRadius = true;
            distanceJoint.connectedBody = collision.attachedRigidbody;
        }
    }

    /// <summary>
    /// Casts a box directly under the player character, then checks for if that box collides with anything from jumpableGround (currently set to Layer: Ground).
    /// </summary>
    /// <returns>returns true if a collision happens (meaning we are touching the ground), false if there is no collision.</returns>
    private bool isGrounded()
    {
        return Physics2D.BoxCast(capsuleCollider.bounds.center, capsuleCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
