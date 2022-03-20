using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingTestCode : MonoBehaviour
{

    private Rigidbody2D rigidBody;

    public GameObject rotateAround;

    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.RotateAround(rotateAround.transform.position, new Vector3(0, 0, 1), moveSpeed * Time.deltaTime);
    }
}
