using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float boundsLeft;
    [SerializeField] float boundsRight;

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
        float delta = moveInput * moveSpeed * Time.deltaTime;
        float newPosX = Mathf.Clamp(transform.position.x + delta, boundsLeft, boundsRight);

        transform.position = new Vector2(newPosX, transform.position.y);
    }
}
