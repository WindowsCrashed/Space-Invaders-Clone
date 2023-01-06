using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyColumn : MonoBehaviour
{
    [SerializeField] List<EnemyController> enemies;
    [SerializeField] EnemyColumnShooting shooter;

    public List<EnemyController> Enemies => enemies;
    public EnemyColumnShooting Shooter => shooter;

    public readonly UnityEvent OnEmptyColumn = new();
    public static readonly UnityEvent OnEnemyRemoved = new();

    public void RemoveFromColumn(EnemyController enemy)
    {
        Enemies.Remove(enemy);
        OnEnemyRemoved.Invoke();

        if (Enemies.Count == 0) OnEmptyColumn.Invoke();
    }
}
