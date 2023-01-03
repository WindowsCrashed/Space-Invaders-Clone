using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider2d;
    [SerializeField] Destroyer destroyer;
    [SerializeField] PlayerController controller;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collider2d.IsTouchingLayers(LayerMask.GetMask("Enemy")) &&
            collision.CompareTag("Projectile"))
        {
            if (!controller.IsDead)
            {
                controller.Die();
                destroyer.ExplodeAsync(null, GameManager.TakeLifeEvent.Invoke);
            }
            
            Destroy(collision.gameObject);
        }
    }
}
