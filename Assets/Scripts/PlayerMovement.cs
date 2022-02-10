using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed Variables
    public float moveSpeed = 3f;
    public float jumpSpeed = 4f;


    public float leftAngle = -35f;
    public float rightAngle = 35f;
    public float swingSpeed = 15f;

    public float angle;


    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private DistanceJoint2D dj;

    public LayerMask jumpableGround;

    public Hooker hook;

    public GameObject hookReference;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        dj = this.GetComponent<DistanceJoint2D>();




        //Sets the anchor point to us then turns the Joint off.
        dj.anchor.Set(0f, 0f);
        dj.enabled = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hooker.SetActive(false);
        //Left and Right Movement
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Change position of HookPoint relative to Motion
        if (dirX > 0)
        {

            //hookReference.transform.localPosition = new Vector2(1f, .5f);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (dirX < 0)
        {
            //hookReference.transform.localPosition = new Vector2(-1f, .5f);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        //Reset Hook Status
        if (isGrounded())
        {
            hook.setHookStatus(false);
        }

        //Jumping
        if (Input.GetKey(KeyCode.UpArrow) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }

        //Can only Swing in the Air
        if (Input.GetKey(KeyCode.Space) && hook.getHookStatus() == true && !isGrounded())
        {
            Debug.Log("Test");

            //Rotaiton movement


            dj.connectedBody = hook.getRB();
            dj.enabled = true;

        }
        else
        {
            dj.enabled = false;
        }


    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
