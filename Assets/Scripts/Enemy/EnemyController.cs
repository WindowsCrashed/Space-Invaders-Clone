using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{
    [SerializeField] EnemyColumn column;
    [SerializeField] Transform gun;
    [SerializeField] SpriteController spriteController;
    [SerializeField] Score score;
    [SerializeField] AudioSource audioSource;

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
        column.RemoveFromColumn(this);
        SetDead();
        audioSource.Play();
        score.ScorePoints();
    }
}
