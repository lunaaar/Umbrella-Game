using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Speed Variables
    [Header("Movement")]
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

    public Rigidbody2D rigidBody;
    private BoxCollider2D boxCollider;
    public DistanceJoint2D distanceJoint;
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// This is the Layer within unity that all the ground will be apart of, and what we consider to be counted as ground.
    /// </summary>
    public LayerMask jumpableGround;


    [Header("Boolean Values")]
    /// <summary>
    /// Boolean value that is true when we the conditions are met that allow us to perform a hook.
    ///      Current Condition: are we within a set radius of a Hook Point
    /// </summary>
    [SerializeField]
    private bool withinHookRadius;

    /// <summary>
    /// Boolean value that is associated with whether or not the directional input will be applied.
    /// </summary>
    [SerializeField]
    private bool canMove;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        distanceJoint = GetComponent<DistanceJoint2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Sets the anchor point to us then turns the Joint off.
        distanceJoint.connectedBody = rigidBody;
        distanceJoint.enabled = false;

        canMove = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput;
        if (canMove)
        {
            //Gets Input from unity horizontal axis. Raw determines that it is always only -1, 0, or 1.
            horizontalInput = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector2(horizontalInput * moveSpeed, rigidBody.velocity.y);
        }

        //Checks if the player is grounded, if so resets our ability to have the option to hook.
        if (isGrounded())
        {
            withinHookRadius = false;
        }

        //just a debug implementation of Save so we can test loading
        if (Input.GetKey(KeyCode.U))
        {
            SaveSystem.save1();
            Debug.Log("Game Saved");
        }


        //Checks to see if any of "Space, W, Up Arrow" are pressed and if we are grounded, if so we jump.
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded())
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);

        }
        
        // Checks to see if the condition that we can hook as been met.
        // The current condition is as follows: Key is being pressed, we are within the radius of a hookpoint to hook, and we are not grounded.
        if (Input.GetKey(KeyCode.LeftShift) &&  canSwing())
        {
            // Turns on the distance joint to perform the swing.
            distanceJoint.enabled = true;
            canMove = false;
        }
        else // If any of the condition is not met, meaning we are not attempting to swing. We turn the DistanceJoint2D off.
        {
            canMove = true;
            distanceJoint.enabled = false;
        }
    }

    public void Move(float move)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Checks to see if we collide with a Trigger specifically with the tag HookPoint.
        if (collision.tag == "HookPoint")
        {
            //If we do trigger properly, allow the option to hook and set the rigidbody of the distance joint to the hookpoint.
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
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    /// <summary>
    /// Checks for if the player can swing, which is based on the following condition:
    ///     We are within the Trigger of a Hook Point, and we are in the air.
    /// </summary>
    /// <returns></returns>
    private bool canSwing()
    {
        // TODO: Change the Input to have a field such that the button is configurable.

        return withinHookRadius && !isGrounded();
    }

    public void setWithinHookRadius(bool r)
    {
        withinHookRadius = r;
    }
}
