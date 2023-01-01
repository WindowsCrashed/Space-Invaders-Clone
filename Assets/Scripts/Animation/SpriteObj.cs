using UnityEngine;

[System.Serializable]
public class SpriteObj
{
    [SerializeField] string name;
    [SerializeField] Sprite sprite;
    [Header("Optional")]
    [SerializeField] Vector2 position;

    public string Name => name;
    public Sprite Sprite => sprite;
    public Vector2 Position => position;
}
