using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float stepX;
    [SerializeField] float stepY;
    [SerializeField] float stepDelay;

    bool hasCollided = false;
    System.Action step;

    public static readonly UnityEvent OnMove = new();

    void Start()
    {
        step = StepSide;
        StartCoroutine(Move());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided && collision.CompareTag("Border"))
        {
            hasCollided = true;
            
            FlipDirection();
            step = StepDown;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        hasCollided = false;
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(stepDelay);

        while (true)
        {
            step();
            OnMove.Invoke();
            yield return new WaitForSeconds(stepDelay);
        }
    }

    void FlipDirection()
    {
        stepX = -stepX;
    }

    void StepSide()
    {
        transform.position += new Vector3(stepX, 0, 0);
    }

    void StepDown()
    {
        transform.position -= new Vector3(0, stepY, 0);
        step = StepSide;
    }
}
