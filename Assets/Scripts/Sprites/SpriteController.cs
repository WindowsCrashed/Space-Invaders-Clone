using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("")]
    [SerializeField] List<SpriteObj> sprites;
    [SerializeField] List<SpriteAnimation> animations;

    IEnumerator AnimationCoroutine(string name, bool loop)
    {
        var animation = animations.Find(a => a.Name == name);

        do
        {
            for (int i = 0; i < animation.Sprites.Length; i++)
            {
                SetSprite(animation.GetCurrentSpriteObj());
                yield return new WaitForSeconds(animation.Interval);
            }
        } while (loop);  
    }

    public void SetSprite(string name)
    {
        if (sprites == null) return;

        SpriteObj sprite = sprites.Find(s => s.Name == name);

        if (sprite.Position != Vector2.zero)
        {
            spriteRenderer.gameObject.transform.localPosition = sprite.Position;
        }

        spriteRenderer.sprite = sprite.Sprite;
    }

    public void SetSprite(SpriteObj sprite)
    {
        if (sprite == null) return;

        if (sprite.Position != Vector2.zero)
        {
            spriteRenderer.gameObject.transform.localPosition = sprite.Position;
        }

        spriteRenderer.sprite = sprite.Sprite;
    }

    public void Animate(string name)
    {
        if (animations == null) return; 
        spriteRenderer.sprite = animations.Find(a => a.Name == name).GetNextSprite();
    }

    public void AnimateAuto(string name, bool loop = false)
    {
        if (animations == null) return;
        StartCoroutine(AnimationCoroutine(name, loop));        
    }
}
