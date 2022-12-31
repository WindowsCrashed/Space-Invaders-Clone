using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform gun;

    SpriteController spriteController;
    bool isDead;

    public Transform Gun => gun;

    void Awake()
    {
        spriteController = GetComponent<SpriteController>();
        GetComponentInParent<EnemyMovement>()
            .moveEvent.AddListener(() => 
            {
                if (!isDead) spriteController.UpdateSprite(); 
            });
    }

    public void SetDead()
    {
        isDead = true;
    }
}
