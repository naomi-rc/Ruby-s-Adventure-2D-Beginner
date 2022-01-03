using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    
    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidBody;
    Animator _animator;
    Vector2 lookDirection = new Vector2(1, 0);
    float horizontal;
    float vertical;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        _animator.SetFloat("Look X", lookDirection.x);
        _animator.SetFloat("Look Y", lookDirection.y);
        _animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        position.x += speed * horizontal * Time.deltaTime;
        position.y += speed * vertical * Time.deltaTime;

        rigidBody.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            _animator.SetTrigger("Hit");

            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;            
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

}
