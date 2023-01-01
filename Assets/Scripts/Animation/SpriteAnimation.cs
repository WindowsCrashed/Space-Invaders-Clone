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
        currentFrame = currentFrame < Sprites.Length - 1 ? currentFrame + 1 : 0;
    }

    public Sprite GetCurrentSprite()
    {
        UpdateFrame();
        return Sprites[currentFrame].Sprite;
    }
}
