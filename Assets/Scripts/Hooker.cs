using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is being left around. However please have it be noted that this code is not used at all anymore.
/// </summary>

public class Hooker : MonoBehaviour
{
    [SerializeField]
    private bool goodToHook;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        goodToHook = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "HookPoint")
        {
            goodToHook = true;

            rb = collision.attachedRigidbody;

            //Debug.Log("Tried to Hook");
        }
    }

    public bool getHookStatus()
    {
        return goodToHook;
    }

    public void setHookStatus(bool stat)
    {
        goodToHook = stat;
    }

    public Rigidbody2D getRB()
    {
        return rb;
    }
}
