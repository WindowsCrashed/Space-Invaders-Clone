using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] Sprite primarySprite;
    [SerializeField] Sprite secondarySprite;
    [SerializeField] SpriteRenderer spriteRenderer;

    Sprite[] sprites;
    int currentIndex;

    void Awake()
    {
        sprites = new[] { primarySprite, secondarySprite };    
    }

    public void UpdateSprite()
    {
        currentIndex = Mathf.Abs(currentIndex - 1);
        spriteRenderer.sprite = sprites[currentIndex];
    }
}
