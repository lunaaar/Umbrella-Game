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
    private CapsuleCollider2D cc;
    private DistanceJoint2D dj;
    private SpriteRenderer sr;

    public LayerMask jumpableGround;

    //public Hooker hook
    [SerializeField]
    private bool hookAvailable;
    [SerializeField]
    private bool stillConnected;

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
        //Hooker.SetActive(false);
        //Left and Right Movement
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Change position of HookPoint relative to Motion
        /**if (dirX > 0)
        {

            //hookReference.transform.localPosition = new Vector2(1f, .5f);
            this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (dirX < 0)
        {
            //hookReference.transform.localPosition = new Vector2(-1f, .5f);
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }**/

        sr.sprite = baseSprite;

        //Reset Hook Status
        if (isGrounded())
        {
            hookAvailable = false;
            stillConnected = false;
        }

        //Jumping
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);

        }

        //Can only Swing in the Air
        if (Input.GetKey(KeyCode.LeftShift) && hookAvailable && !isGrounded())
        {
            //Debug.Log("Test");

            //Rotaiton movement
            dj.enabled = true;

        }
        else
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //Debug.Log("TEST2");
            }
            
            dj.enabled = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stillConnected = true;

        if (collision.tag == "HookPoint")
        {
            hookAvailable = true;
            dj.connectedBody = collision.attachedRigidbody;


        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.tag == "HookPoint")
        {
            Debug.Log("TEST");
        }
        
        if (collision.tag == "HookPoint" && stillConnected == false)
        {
            Debug.Log("TEST3");
            sr.sprite = secondSprite;
            hookAvailable = false;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(cc.bounds.center, cc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
