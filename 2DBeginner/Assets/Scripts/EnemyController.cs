using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 2.0f;
    public int horizontal = 1;
    public int vertical = 0;
    public float timeTillDirectionSwitch = 4.0f;
    

    Rigidbody2D _rigidBody;
    float _directionSwitchTimer;
    int _damage = -2;
    

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _directionSwitchTimer = timeTillDirectionSwitch;
    }

    private void Update()
    {
        _directionSwitchTimer -= Time.deltaTime;

        if(_directionSwitchTimer < 0)
        {
            horizontal = -horizontal;
            vertical = -vertical;
            _directionSwitchTimer = timeTillDirectionSwitch;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = _rigidBody.position;
        position.x += horizontal * speed * Time.deltaTime;
        position.y += vertical * speed * Time.deltaTime;
        _rigidBody.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        RubyController player = collider.gameObject.GetComponent<RubyController>();

        if(player != null)
        {
            player.ChangeHealth(_damage);
        }
    }
}
