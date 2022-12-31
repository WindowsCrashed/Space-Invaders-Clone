using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColumnShooting : MonoBehaviour
{
    [SerializeField] List<EnemyController> enemies;
    [SerializeField] EnemyShooting enemyShooting;

    Coroutine shootingCoroutine;

    void Start()
    {
        shootingCoroutine = StartCoroutine(ShootingCoroutine());
    }

    IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetRandomShootingTime());

            GameObject proj = Instantiate(enemyShooting.Projectile, enemies[0].Gun.position, Quaternion.identity);

            if (proj.TryGetComponent(out Rigidbody2D rb)) rb.velocity = enemies[0].Gun.up * enemyShooting.Speed;

            if (proj.GetComponentInChildren<Animator>())
            {
                FindObjectOfType<AnimationManager>().SetAnimatorController(proj.GetComponentInChildren<Animator>());
            }
        }
    }

    float GetRandomShootingTime()
    {
        return Random.Range(enemyShooting.MinShootingTime, enemyShooting.MaxShootingTime);
    }

    void StopShooting()
    {
        StopCoroutine(shootingCoroutine);
        shootingCoroutine = null;
    }

    public void RemoveFromColumn(GameObject enemy)
    {
        enemies.Remove(enemy.GetComponent<EnemyController>());

        if (enemies.Count == 0) StopShooting();
    }
}
