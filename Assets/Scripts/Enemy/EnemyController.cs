using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform gun;

    SpriteController spriteController;
    public bool IsDead { get; private set; }

    public Transform Gun => gun;

    void Awake()
    {
        spriteController = GetComponent<SpriteController>();
        GetComponentInParent<EnemyMovement>()
            .moveEvent.AddListener(() => 
            {
                if (!IsDead) spriteController.UpdateSprite(); 
            });
    }

    public void SetDead()
    {
        IsDead = true;
    }
}
