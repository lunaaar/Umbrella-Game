using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooker : MonoBehaviour
{
    [SerializeField]
    private bool goodToHook;

    // Start is called before the first frame update
    void Start()
    {
        goodToHook = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "HookPoint")
        {
            goodToHook = true;
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
}
