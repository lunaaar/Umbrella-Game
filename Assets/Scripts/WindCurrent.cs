using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindCurrent : MonoBehaviour
{
    public float speed;

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            Vector2 force = new Vector2(0, Mathf.Cos(Mathf.Abs(this.transform.rotation.eulerAngles.z)));
            collision.GetComponent<PlayerMovement>().rigidBody.AddForce( force * speed, ForceMode2D.Force);
        }
    }
}
