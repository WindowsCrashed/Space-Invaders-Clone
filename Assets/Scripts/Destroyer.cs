using System;
using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyDelay;
    [SerializeField] SpriteController spriteController;

    IEnumerator ExplosionCoroutine(string sprite, Action next)
    {
        if (spriteController != null) spriteController.SetSprite(sprite);
        yield return new WaitForSecondsRealtime(destroyDelay);
        Destroy(gameObject);
        next?.Invoke();
    }

    public void Explode(string sprite = "Death")
    {
        if (spriteController != null) spriteController.SetSprite(sprite);
        Destroy(gameObject, destroyDelay);        
    }

    public void ExplodeAsync(string sprite = "Death", Action next = null)
    {
        StartCoroutine(ExplosionCoroutine(sprite, next));
    }
}
