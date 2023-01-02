using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("")]
    [SerializeField] List<SpriteObj> sprites;
    [SerializeField] List<SpriteAnimation> animations;

    public void SetSprite(string name)
    {
        if (sprites == null) return;

        SpriteObj sprite = sprites.Where(s => s.Name == name).First();

        if (sprite.Position != Vector2.zero)
        {
            spriteRenderer.gameObject.transform.localPosition = sprite.Position;
        }

        spriteRenderer.sprite = sprite.Sprite;
    }

    public void Animate(string name)
    {
        if (animations == null) return; 
        spriteRenderer.sprite = animations.Where(a => a.Name == name).First().GetCurrentSprite();
    }
}
