using UnityEngine;

public class EnemyController : MonoBehaviour
{
    SpriteController spriteController;
    bool isDead;

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
