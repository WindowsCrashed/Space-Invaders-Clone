using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite deathSprite;
    [SerializeField] float destroyDelay;

    public void Explode()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        spriteRenderer.sprite = deathSprite;
        Destroy(gameObject, destroyDelay);
    }
}
