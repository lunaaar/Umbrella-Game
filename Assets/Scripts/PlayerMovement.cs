using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Speed Variables
    public float moveSpeed = 3f;
    public float jumpSpeed = 4f;
    public float swingSpeed = 15f;


    [SerializeField]
    private Rigidbody2D rb;
    private BoxCollider2D bc;

    public LayerMask jumpableGround;

    public Hooker hook;

    public GameObject hookReference;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Hooker.SetActive(false);
        //Left and Right Movement
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        //Change position of HookPoint relative to Motion
        if (dirX == 1)
        {

            hookReference.transform.localPosition = new Vector2(1f, .5f);
        }
        else if (dirX == -1)
        {
            hookReference.transform.localPosition = new Vector2(-1f, .5f);
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

            //transform.RotateAround(rotateAround.transform.position, Vector3.forward, swingSpeed * Time.deltaTime);
            Debug.Log("Test");
        }


    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
