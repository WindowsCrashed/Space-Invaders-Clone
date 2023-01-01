using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    //[SerializeField] List<ISpriteController> controllers;
    //[SerializeField] List<SpriteAnimationController> controllers;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] List<SpriteObj> sprites;
    [SerializeField] List<SpriteAnimation> animations;

    public void SetSprite(string name)
    {
        sprites.Where(s => s.Name == name).First();
    }

    //public void Animate()
    //{
    //    controllers.Where(c => c is SpriteAnimationController).First();
    //}
}
