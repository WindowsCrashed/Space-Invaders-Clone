using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyDelay;

    SpriteController spriteController;

    void Awake()
    {
        spriteController = GetComponent<SpriteController>();
    }

    public void Explode()
    {
        spriteController.SetSprite("Death");
        Destroy(gameObject, destroyDelay);
    }
}
