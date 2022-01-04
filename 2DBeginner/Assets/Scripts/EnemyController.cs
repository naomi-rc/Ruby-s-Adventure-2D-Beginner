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
    Animator _animator;
    float _directionSwitchTimer;
    int _damage = -2;
    bool broken = true;

    

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _directionSwitchTimer = timeTillDirectionSwitch;
    }

    private void Update()
    {
        if (!broken)
            return;

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
        if (!broken)
            return;

        Vector2 position = _rigidBody.position;
        position.x += horizontal * speed * Time.deltaTime;
        position.y += vertical * speed * Time.deltaTime;
        _rigidBody.MovePosition(position);

        _animator.SetFloat("Move X", horizontal);
        _animator.SetFloat("Move Y", vertical);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        RubyController player = collider.gameObject.GetComponent<RubyController>();

        if(player != null)
        {
            player.ChangeHealth(_damage);
        }
    }

    public void Fix()
    {
        broken = false;
        _rigidBody.simulated = false;
        _animator.SetTrigger("Fixed");
        Debug.Log("Fixed robot with Cog");
    }
}
