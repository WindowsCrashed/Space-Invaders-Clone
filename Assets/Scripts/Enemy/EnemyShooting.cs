using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] EnemyGroup enemyGroup;
    [SerializeField] List<GameObject> projectiles;
    [SerializeField] float projetileSpeed;

    EnemyFireRateController fireRateController;
    Coroutine shootingCoroutine;
    int currentProjectile;

    public float Speed => projetileSpeed;

    public static UnityEvent OnStartShooting = new();

    void Awake()
    {
        fireRateController = FindObjectOfType<EnemyFireRateController>();
        OnStartShooting.AddListener(StartShooting);
    }

    void Start()
    {
        foreach (EnemyColumn column in enemyGroup.Columns)
        {
            column.OnEmptyColumn.AddListener(() => RemoveColumn(column));
        }       
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
        return Random.Range(fireRateController.MinShootingTime, fireRateController.MaxShootingTime);
    }

    int GetRandomColumn()
    {
        return Random.Range(0, enemyGroup.Columns.Count - 1);
    }

    void StartShooting()
    {
        shootingCoroutine = StartCoroutine(ShootingCoroutine());
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
