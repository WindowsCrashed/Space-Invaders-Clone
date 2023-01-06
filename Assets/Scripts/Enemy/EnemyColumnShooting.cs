using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyColumnShooting : MonoBehaviour
{
    [SerializeField] List<EnemyController> enemies;
    [SerializeField] EnemyShooting enemyShooting;

    public List<EnemyController> Enemies => enemies;

    public readonly UnityEvent OnEmptyColumn = new();
    public static readonly UnityEvent OnEnemyRemoved = new();

    public void Shoot()
    {
        Shooter.Shoot(enemyShooting.GetCurrentProjectile(), enemies[0].Gun, enemyShooting.Speed);
    }

    public void RemoveFromColumn(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<EnemyController>());
        OnEnemyRemoved.Invoke();

        if (enemies.Count == 0) OnEmptyColumn.Invoke();
    }
}
