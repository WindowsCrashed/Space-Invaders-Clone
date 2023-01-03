using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyColumnShooting column;
    [SerializeField] Transform gun;
    [SerializeField] SpriteController spriteController;
    public bool IsDead { get; private set; }

    public Transform Gun => gun;

    void Awake()
    {
        EnemyMovement.MoveEvent.AddListener(() => 
            {
                if (!IsDead) spriteController.Animate("Move"); 
            });
    }

    void SetDead()
    {
        IsDead = true;
    }

    public void Die()
    {
        column.RemoveFromColumn(gameObject);
        SetDead();
    }
}
