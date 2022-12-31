using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite deathSprite;
    [SerializeField] float destroyDelay;

    public void Explode()
    {
        spriteRenderer.sprite = deathSprite;
        Destroy(gameObject, destroyDelay);
    }
}
