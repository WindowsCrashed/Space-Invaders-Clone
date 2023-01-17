using System;
using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float destroyDelay;
    [SerializeField] SpriteController spriteController;

    AudioManager audioManager;

    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();    
    }

    IEnumerator ExplosionCoroutine(string sprite, Action next)
    {
        if (spriteController != null) spriteController.SetSprite(sprite);
        yield return new WaitForSecondsRealtime(destroyDelay);
        Destroy(gameObject);
        next?.Invoke();
    }

    public void Explode(string sound = null, string sprite = "Death")
    {
        if (sound != null) audioManager.PlayClip(sound);
        if (spriteController != null) spriteController.SetSprite(sprite);
        Destroy(gameObject, destroyDelay);        
    }

    public void ExplodeAsync(string sound = null, string sprite = "Death", Action next = null)
    {
        if (sound != null) audioManager.PlayClip(sound);
        StartCoroutine(ExplosionCoroutine(sprite, next));
    }
}
