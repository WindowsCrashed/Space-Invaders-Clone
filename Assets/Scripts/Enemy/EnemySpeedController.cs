using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    [SerializeField] EnemyShooting enemyShooting;
    [SerializeField] EnemyMovement enemyMovement;
    [SerializeField] float stepDelay;
    [SerializeField] float minStepDelay;

    public float StepDelay => stepDelay;

    void Start()
    {
        EnemyColumnShooting.OnEnemyRemoved.AddListener(ControlSpeed);    
    }

    int CountEnemies()
    {
        int counter = 0;

        foreach (EnemyColumnShooting column in enemyShooting.Columns)
        {
            foreach (EnemyController enemy in column.Enemies)
            {
                counter++;
            }
        }

        return counter;
    }

    void ControlSpeed()
    {
        int enemyCount = CountEnemies();

        // Temp -----------
        if (enemyCount == 0)
        {
            GameManager.OnGameWin.Invoke();
            return;
        }
        // ----------------

        if (enemyCount >= 50 || stepDelay <= 0.01) return;

        float moveSpeed = minStepDelay * enemyCount;

        stepDelay = moveSpeed;
    }
}
