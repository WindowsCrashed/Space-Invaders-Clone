using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] EnemyGroup enemyGroup;
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] float minShootingTime;
    [SerializeField] float maxShootingTime;
    [SerializeField] float projetileSpeed;

    public float Speed => projetileSpeed;

    Coroutine shootingCoroutine;
    int currentProjectile;

    void Start()
    {
        foreach (EnemyColumn column in enemyGroup.Columns)
        {
            column.OnEmptyColumn.AddListener(() => RemoveColumn(column));
        }

        shootingCoroutine = StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomShootingTime());

            enemyGroup.Columns[GetRandomColumn()].Shooter.Shoot();
        }
    }

    float GetRandomShootingTime()
    {
        return Random.Range(minShootingTime, maxShootingTime);
    }

    int GetRandomColumn()
    {
        return Random.Range(0, enemyGroup.Columns.Count - 1);
    }

    void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    void RemoveColumn(EnemyColumn column)
    {
        enemyGroup.RemoveColumn(column);

        if (enemyGroup.Columns.Count == 0) StopShooting();
    }

    void UpdateProjectile()
    {
        currentProjectile = currentProjectile < projectiles.Count - 1 ? currentProjectile + 1 : 0;
    }

    public GameObject GetCurrentProjectile()
    {
        GameObject proj = projectiles[currentProjectile];
        UpdateProjectile();
        return proj;
    }
}
