using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPoint : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collision.GetComponent<PlayerMovement>().distanceJoint.enabled)
        {
            collision.GetComponent<PlayerMovement>().setWithinHookRadius(false);
        }
    }
}
