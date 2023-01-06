using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    [SerializeField] EnemyGroup enemyGroup;
    [SerializeField] float stepDelay;
    [SerializeField] float minStepDelay;

    public float StepDelay => stepDelay;

    void Start()
    {
        EnemyColumn.OnEnemyRemoved.AddListener(ControlSpeed);    
    }

    int CountEnemies()
    {
        int counter = 0;

        foreach (EnemyColumn column in enemyGroup.Columns)
        {
            counter += column.Enemies.Count;
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
