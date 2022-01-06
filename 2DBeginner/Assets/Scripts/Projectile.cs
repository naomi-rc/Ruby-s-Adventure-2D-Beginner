using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public ParticleSystem hitEffect;

    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(transform.position.magnitude > 300.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        _rigidbody.AddForce(direction * force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitEffect != null)
            Instantiate(hitEffect, _rigidbody.position, Quaternion.identity);
            //hitEffect.Play();

        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();

        if(enemyController != null)
        {
            enemyController.Fix();
        }
        Debug.Log("Cog hit " + collision.gameObject);
        Destroy(gameObject);
    }
}
