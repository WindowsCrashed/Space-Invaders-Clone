using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider2d;
    [SerializeField] Destroyer destroyer;
    [SerializeField] EnemyController controller;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collider2d.IsTouchingLayers(LayerMask.GetMask("Player")) &&
            collision.CompareTag("Projectile"))
        {
            if (!controller.IsDead) {
                controller.Die();
                destroyer.Explode();
            }
                       
            Destroy(collision.gameObject);    
        }
    }
}
