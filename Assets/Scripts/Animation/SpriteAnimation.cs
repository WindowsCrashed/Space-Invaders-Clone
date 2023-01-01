using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteAnimation
{
    [SerializeField] string name;
    [SerializeField] SpriteObj[] sprites;

    public string Name => name;
    public SpriteObj[] Sprites => sprites;

    int currentFrame = 0;

    void UpdateFrame()
    {
        currentFrame = Mathf.Abs(currentFrame - 1);
    }

    public Sprite GetCurrentSprite()
    {
        
        return sprites[currentFrame].Sprite;
    }
}
