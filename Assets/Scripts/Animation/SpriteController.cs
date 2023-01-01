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
        spriteRenderer.sprite = sprites.Where(s => s.Name == name).First().Sprite;
    }

    public void AnimateSprite(string name)
    {

    }

    //[SerializeField] Sprite primarySprite;
    //[SerializeField] Sprite secondarySprite;
    //[Header("Sec. Sprite Position (optional)")]
    //[SerializeField] Vector2 secondarySpritePosition;
    //[Header("")]
    //[SerializeField] SpriteRenderer spriteRenderer;

    //[Header("")]
    //[SerializeField] List<SpriteObj> spriteObjs;

    //Sprite[] sprites;
    //int currentIndex;

    //void Awake()
    //{
    //    sprites = new[] { primarySprite, secondarySprite };    
    //}

    //public void UpdateSprite()
    //{
    //    currentIndex = Mathf.Abs(currentIndex - 1);
    //    spriteRenderer.sprite = sprites[currentIndex];
    //    if (secondarySpritePosition != Vector2.zero) Debug.Log("Has position"); //spriteRenderer.gameObject.transform.position = secondarySpritePosition;
    //}
}
