using UnityEngine;

public class BarrierCollision : MonoBehaviour
{
    [SerializeField] SpriteController spriteController;
    [SerializeField] BoxCollider2D col2d;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IProjectile projectile))
        {
            projectile.Explode("Death Barrier");
            col2d.enabled = false;
            spriteController.SetSprite("Destroy");
        }
    }
}
