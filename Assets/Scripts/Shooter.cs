using UnityEngine;

public static class Shooter
{
    public static void Shoot(GameObject projectile, Transform gun, float speed,
        bool useAnimation = false)
    {
        GameObject newProjectile = Object.Instantiate(projectile, gun.position, Quaternion.identity);

        if (newProjectile.TryGetComponent(out Rigidbody2D rb)) rb.velocity = gun.up * speed;

        if (useAnimation && newProjectile.GetComponentInChildren<Animator>())
        {
            Object.FindObjectOfType<AnimationManager>()
                .SetAnimatorController(newProjectile.GetComponentInChildren<Animator>());
        }
    }
}
