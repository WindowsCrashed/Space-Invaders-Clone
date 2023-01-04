using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyColumnShooting column;
    [SerializeField] Transform gun;
    [SerializeField] SpriteController spriteController;
    [SerializeField] Score score;

    public bool IsDead { get; private set; }

    public Transform Gun => gun;

    void Awake()
    {
        EnemyMovement.OnMove.AddListener(() => 
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
        score.ScorePoints();
    }
}
