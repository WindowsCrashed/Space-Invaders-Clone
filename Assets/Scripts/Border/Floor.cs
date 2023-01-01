using UnityEngine;

public class Floor : MonoBehaviour
{
    bool isBurned;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IProjectile projectile))
        {
            projectile.Explode();

            if (!isBurned)
            {
                isBurned = true;
                GetComponent<SpriteController>().UpdateSprite();
            }
        }
    }
}
