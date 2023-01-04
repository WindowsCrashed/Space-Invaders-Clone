using UnityEngine;

[System.Serializable]
public class SpriteAnimation
{
    [SerializeField] string name;
    [Header("Optional")]
    [SerializeField] float interval;
    [Header("")]
    [SerializeField] SpriteObj[] sprites;

    public string Name => name;
    public float Interval => interval;
    public SpriteObj[] Sprites => sprites;

    int currentFrame = 0;

    void UpdateFrame()
    {
        currentFrame = currentFrame < Sprites.Length - 1 ? currentFrame + 1 : 0;
    }

    public Sprite GetNextSprite()
    {
        UpdateFrame();
        return Sprites[currentFrame].Sprite;
    }

    public Sprite GetCurrentSprite()
    {
        Sprite sprite = Sprites[currentFrame].Sprite;
        UpdateFrame();
        return sprite;
    }

    public SpriteObj GetCurrentSpriteObj()
    {
        SpriteObj sprite = Sprites[currentFrame];
        UpdateFrame();
        return sprite;
    }
}
