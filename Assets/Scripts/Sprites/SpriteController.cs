using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [Header("")]
    [SerializeField] List<SpriteObj> sprites;
    [SerializeField] List<SpriteAnimation> animations;

    IEnumerator AnimationCoroutine(string name, bool loop)
    {
        var animation = animations.Where(a => a.Name == name).First();

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

        SpriteObj sprite = sprites.Where(s => s.Name == name).First();

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
        spriteRenderer.sprite = animations.Where(a => a.Name == name).First().GetNextSprite();
    }

    public void AnimateAuto(string name, bool loop = false)
    {
        if (animations == null) return;
        StartCoroutine(AnimationCoroutine(name, loop));        
    }
}
