using UnityEngine;

public class EnemySpeedController : MonoBehaviour
{
    [SerializeField] EnemyGroup enemyGroup;
    [SerializeField] float stepDelay;
    [SerializeField] float minStepDelay;

    BackgroundTrackController bgTrackController;

    public float StepDelay => stepDelay;

    void Start()
    {
        bgTrackController = FindObjectOfType<BackgroundTrackController>();
        EnemyColumn.OnEnemyRemoved.AddListener(ControlSpeed);    
    }

    void ControlSpeed()
    {
        int enemyCount = enemyGroup.CountEnemies();

        bgTrackController.ManagePlaybackSpeed(enemyCount);

        if (enemyCount >= 50 || stepDelay <= 0.01) return;

        float moveSpeed = minStepDelay * enemyCount;

        stepDelay = moveSpeed;
    }
}
