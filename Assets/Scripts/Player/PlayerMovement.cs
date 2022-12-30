using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    float moveInput;

    void Update()
    {
        Move();    
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().x;
    }

    void Move()
    {
        transform.position = new Vector2(
            transform.position.x + moveInput * moveSpeed * Time.deltaTime,
            transform.position.y);
    }
}
