using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float minShootingTime;
    [SerializeField] float maxShootingTime;
    [SerializeField] float speed;

    public GameObject Projectile => projectile;
    public float MinShootingTime => minShootingTime;
    public float MaxShootingTime => maxShootingTime;
    public float Speed => speed;
}
