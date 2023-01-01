using UnityEngine;

[System.Serializable]
public class SpriteObj
{
    [SerializeField] string name;
    [SerializeField] Sprite sprite;

    public string Name => name;
    public Sprite Sprite => sprite;
}
