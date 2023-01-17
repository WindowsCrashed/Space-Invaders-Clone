using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] BoxCollider2D collider2d;
    [SerializeField] Destroyer destroyer;
    
    IEnemyController controller;

    void Awake()
    {
        controller = GetComponent<IEnemyController>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collider2d.IsTouchingLayers(LayerMask.GetMask("Player")) &&
            collision.CompareTag("Projectile"))
        {
            if (!controller.IsDead) {
                controller.Die();
                string sound = controller is not BonusEnemyController ? "EnemyDeath" : null;
                destroyer.Explode(sound);
            }
                       
            Destroy(collision.gameObject);
            return;
        }

        if (collider2d.IsTouchingLayers(LayerMask.GetMask("Floor")))
        {
            GameManager.OnGameOver.Invoke();
        }
    }
}
