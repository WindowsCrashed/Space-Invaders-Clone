using UnityEngine;

public class Border : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.TryGetComponent(out Projectile projectile))
        {
            projectile.Explode();
        } 
    }
}
