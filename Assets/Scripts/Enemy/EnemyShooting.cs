using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] List<EnemyColumnShooting> columns;
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] float minShootingTime;
    [SerializeField] float maxShootingTime;
    [SerializeField] float projetileSpeed;

    public float Speed => projetileSpeed;

    Coroutine shootingCoroutine;
    int currentProjectile;

    void Start()
    {
        foreach (EnemyColumnShooting column in columns)
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

            columns[GetRandomColumn()].Shoot();
        }
    }

    float GetRandomShootingTime()
    {
        return Random.Range(minShootingTime, maxShootingTime);
    }

    int GetRandomColumn()
    {
        return Random.Range(0, columns.Count - 1);
    }

    void StopShooting()
    {
        if (shootingCoroutine != null)
        {
            StopCoroutine(shootingCoroutine);
            shootingCoroutine = null;
        }
    }

    void RemoveColumn(EnemyColumnShooting column)
    {
        columns.Remove(column);

        if (columns.Count == 0) StopShooting();
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
