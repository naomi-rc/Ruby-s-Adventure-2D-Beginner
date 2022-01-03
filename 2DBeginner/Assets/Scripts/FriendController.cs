using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        RubyController controller = collider.GetComponent<RubyController>();

        if(controller != null)
        {
            Debug.Log("Hi! I'm Penguy!");
        }
    }
}
