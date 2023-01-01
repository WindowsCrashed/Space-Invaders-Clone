using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.TryGetComponent(out IProjectile projectile))
        {
            projectile.Explode();
        } 
    }
}
