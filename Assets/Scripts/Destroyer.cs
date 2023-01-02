using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyDelay;

    SpriteController spriteController;

    void Awake()
    {
        spriteController = GetComponent<SpriteController>();
    }

    public void Explode(string sprite = "Death")
    {
        spriteController.SetSprite(sprite);
        Destroy(gameObject, destroyDelay);
    }
}
