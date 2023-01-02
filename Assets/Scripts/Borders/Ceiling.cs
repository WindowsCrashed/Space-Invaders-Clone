using UnityEngine;

public class Ceiling : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.TryGetComponent(out IProjectile projectile))
        {
            projectile.Explode();
        } 
    }
}
