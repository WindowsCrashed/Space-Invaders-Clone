using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] EnemyColumnShooting column;

    BoxCollider2D col2d;
    Destroyer destroyer;
    EnemyController controller;

    private void Awake()
    {
        col2d = GetComponent<BoxCollider2D>();
        destroyer = GetComponent<Destroyer>();
        controller = GetComponent<EnemyController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (col2d.IsTouchingLayers(LayerMask.GetMask("Player")) &&
            collision.CompareTag("Projectile"))
        {
            if (!controller.IsDead) {
                column.RemoveFromColumn(gameObject);
                controller.SetDead();
                destroyer.Explode();
            }
                       
            Destroy(collision.gameObject);    
        }
    }
}
