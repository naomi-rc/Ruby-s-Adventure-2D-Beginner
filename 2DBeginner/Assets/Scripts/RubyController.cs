using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidBody;
    float horizontal;
    float vertical;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 position = rigidBody.position;
        position.x += 3.0f * horizontal * Time.deltaTime;
        position.y += 3.0f * vertical * Time.deltaTime;

        rigidBody.MovePosition(position);
    }
}
