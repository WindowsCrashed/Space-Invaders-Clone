using UnityEngine;

public class EnemyColumnShooting : MonoBehaviour
{
    [SerializeField] EnemyShooting enemyShooting;
    [SerializeField] EnemyColumn column;

    public void Shoot()
    {
        Shooter.Shoot(enemyShooting.GetCurrentProjectile(), column.Enemies[0].Gun, enemyShooting.Speed);
    }
}
