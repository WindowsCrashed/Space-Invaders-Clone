using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    BoxCollider2D col2d;
    Destroyer destroyer;

    private void Awake()
    {
        col2d = GetComponent<BoxCollider2D>();
        destroyer = GetComponent<Destroyer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (col2d.IsTouchingLayers(LayerMask.GetMask("Player")) &&
            collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            destroyer.Explode();
        }
    }
}
