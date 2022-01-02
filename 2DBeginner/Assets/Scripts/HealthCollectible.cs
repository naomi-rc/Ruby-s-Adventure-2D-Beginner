using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    int powerUp = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        RubyController controller = collider.GetComponent<RubyController>();

        if(controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(powerUp);
            Destroy(gameObject);
        }        
    }
}
