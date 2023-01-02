using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    BoxCollider2D col2d;
    Destroyer destroyer;
    PlayerController controller;
    
    private void Awake()
    {
        col2d = GetComponent<BoxCollider2D>();
        destroyer = GetComponent<Destroyer>();
        controller = GetComponent<PlayerController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (col2d.IsTouchingLayers(LayerMask.GetMask("Enemy")) &&
            collision.CompareTag("Projectile"))
        {
            if (!controller.IsDead)
            {
                controller.Die();
                destroyer.ExplodeAsync();
            }
            
            Destroy(collision.gameObject);
        }
    }
}
