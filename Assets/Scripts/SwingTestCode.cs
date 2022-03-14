using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTestCode : MonoBehaviour
{
    private DistanceJoint2D dj;
    private Rigidbody2D rb;

    public Rigidbody2D rb2;
    
    // Start is called before the first frame update
    void Start()
    {
        dj = GetComponent<DistanceJoint2D>();
        rb = dj.connectedBody;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.K))
        {
            dj.enabled = true;
        }
        if (Input.GetKey(KeyCode.T)){
            dj.enabled = false;
        }

        if (Input.GetKey(KeyCode.L))
        {
            dj.connectedBody = rb;
        }
        if (Input.GetKey(KeyCode.M))
        {
            dj.connectedBody = rb2;
        }
    }
}
